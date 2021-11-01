using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Common.ViewModels
{
    public static class ResponseMessage
    {
        public static ApiResponse<T> SuccessMessage<T>(T data, string message = null)
        {
            return new ApiResponse<T>
            {

                Code = ApiResponseCodes.OK,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> ErrorMessage<T>(string error = null, ApiResponseCodes responseCodes = ApiResponseCodes.FAIL)
        {
            return new ApiResponse<T>
            {

                Code = responseCodes,
                Message = error ?? "An error occurred,please try again",

            };
        }

        public static ApiResponse<T> ErrorMessage<T>(T data, string error = null, ApiResponseCodes responseCodes = ApiResponseCodes.FAIL)
        {
            return new ApiResponse<T>
            {

                Code = responseCodes,
                Data = data,
                Message = error ?? "An error occurred,please try again",

            };
        }
    }
}
