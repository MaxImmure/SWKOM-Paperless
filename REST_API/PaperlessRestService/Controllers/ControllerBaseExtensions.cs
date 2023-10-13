using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace PaperlessRestService.Controllers
{
    internal static class ControllerResponseFactory
    {
        public static IActionResult CreateErrorResponseFromValidationFail(ControllerBase controller, ValidationResult result)
        {
            StringBuilder sb = new();
            foreach (var failure in result.Errors)
            {
                sb.AppendLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }

            return controller.BadRequest(sb.ToString());
        }
    }
}
