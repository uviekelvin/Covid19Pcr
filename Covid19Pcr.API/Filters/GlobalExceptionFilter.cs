﻿using Covid19Pcr.Common.ViewModels;
using Covid19Pcr.Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Covid19Pcr.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment env;
        private readonly ILogger<GlobalExceptionFilter> _logger;


        public GlobalExceptionFilter(IHostEnvironment env, ILogger<GlobalExceptionFilter> logger)
        {
            this.env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {

            ApiResponse<string> apiResponse = new ApiResponse<string>()
            {
                Data = null,
                Code = ApiResponseCodes.ValidationError
            };
            if (context.Exception.GetType() == typeof(DomainException))
            {
                apiResponse.Message = context.Exception.Message.ToString();
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                context.Result = new BadRequestObjectResult(apiResponse);
            }
            else if (context.Exception.GetType() == typeof(DbUpdateException))
            {
                var dbUpdateEx = context.Exception as DbUpdateException;
                var sqlEx = dbUpdateEx?.InnerException as SqlException;
                if (sqlEx != null && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                {
                    //This is a DbUpdateException on a SQL database
                    apiResponse.Message = UniqueErrorFormatter(sqlEx, dbUpdateEx.Entries);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    context.Result = new BadRequestObjectResult(apiResponse);
                }
            }
            else if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
            }
            else
            {
                apiResponse.Message = "An error occurred please try again";
                if (env.IsDevelopment())
                {
                    apiResponse.Message = context.Exception.ToString();
                }
                // Result asigned to a result object but in destiny the response is empty. This is a known bug of .net core 1.1
                // It will be fixed in .net core 1.1.2. See https://github.com/aspnet/Mvc/issues/5594 for more information

                context.Result = new BadRequestObjectResult(apiResponse);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var logKey = Guid.NewGuid();
                apiResponse.Message = $"{apiResponse.Message}  Code: {logKey}";
                _logger.LogError(context.Exception, $"ErrorID={logKey}");
            }

            context.ExceptionHandled = true;
        }


        public static string UniqueErrorFormatter(SqlException ex, IReadOnlyList<EntityEntry> entitiesNotSaved)
        {
            var message = ex.Errors[0].Message;
            var matches = UniqueConstraintRegex.Matches(message);

            if (matches.Count == 0)
                return null;

            //currently the entitiesNotSaved is empty for unique constraints - see https://github.com/aspnet/EntityFrameworkCore/issues/7829
            var entityDisplayName = entitiesNotSaved.Count == 1
                ? entitiesNotSaved.Single().Entity.GetType().Name
                : matches[0].Groups[1].Value;

            var returnError = " " +
                              matches[0].Groups[2].Value + " in " +
                              entityDisplayName + ".";
            returnError = $"{entityDisplayName} with matching {matches[0].Groups[2].Value} already exists";
            return returnError;
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
            var response = new ApiResponse<IEnumerable<string>>();

            response.Code = ApiResponseCodes.ValidationError;
            var message = context.ModelState.Values.SelectMany(a => a.Errors).Select(e => e.ErrorMessage);
            var lst = new List<string>();
            lst.AddRange(message);
            response.Message = lst.FirstOrDefault();
            context.Result = new BadRequestObjectResult(response);
        }
        private static readonly Regex UniqueConstraintRegex =
            new Regex("IX_([a-zA-Z0-9]*)_([a-zA-Z0-9]*)'", RegexOptions.Compiled);
    }
}
