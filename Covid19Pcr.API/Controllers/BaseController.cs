using Covid19Pcr.Common.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Covid19Pcr.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IActionResult CustomResponse<T>(ApiResponse<T> result)
        {

            switch (result.Code)
            {

                case ApiResponseCodes.ValidationError:
                case ApiResponseCodes.FAIL:
                    return BadRequest(result);
                case ApiResponseCodes.NOT_FOUND:
                    return NotFound(result);
                default:
                    return Ok(result);
            }
        }

    }
}

