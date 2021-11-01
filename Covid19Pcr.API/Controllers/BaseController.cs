using Covid19Pcr.Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid19Pcr.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
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

