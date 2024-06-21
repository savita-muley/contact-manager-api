using ContactManagement.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ContactManagement.API.Helpers
{
    public class ResponseHelper
    {
        public static IActionResult SuccessResult(string? message = "")
        {
            return new ObjectResult(new SuccessResponse<object> { Success = true, Message = message, Data = null })
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult SuccessResult<T>(T response) where T : class
        {
            return new ObjectResult(new SuccessResponse<T> { Success = true, Message = string.Empty, Data = response })
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult SuccessResult<T>(T response, string message) where T : class
        {
            return new ObjectResult(new SuccessResponse<T> { Success = true, Message = message, Data = response })
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult FailureResult(string message)
        {
            return new ObjectResult(new ErrorResponse { Success = false, Message = message })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
