using Microsoft.Extensions.Logging;

namespace PaperlessRestService.BusinessLogic.ExceptionHandling
{
    public class ErrorHandler : IErrorHandler
    {
        public void HandleError(Exception ex, ILogger logger)
        {
            logger.LogError(ex, ex.Message);
        }
    }
}
