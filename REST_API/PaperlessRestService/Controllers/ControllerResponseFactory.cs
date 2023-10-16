using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace PaperlessRestService.Controllers
{
    internal static class ControllerResponseFactory
    {
        public static IActionResult CreateBadRequestResponseFromValidationFail(ValidationResult result)
        {
            StringBuilder sb = new();
            foreach (var failure in result.Errors)
            {
                sb.AppendLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }

            return new BadRequestObjectResult(sb.ToString());
        }

        public static IActionResult CreateBadRequestResponse(string message)
        {
            return new BadRequestObjectResult(message);
        }

        public static IActionResult CreateErrorResponse(string message)
        {
            ObjectResult result = new ObjectResult(message);
            result.StatusCode = 500;
            return result;
        }

        public static IActionResult CreateSuccessResponse()
        {
            StatusCodeResult result = new StatusCodeResult(StatusCodes.Status200OK);
            return result;
        }

        public static IActionResult CreateSuccessResponse(object value)
        {
            ObjectResult result = new ObjectResult(value);
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }
    }
}
