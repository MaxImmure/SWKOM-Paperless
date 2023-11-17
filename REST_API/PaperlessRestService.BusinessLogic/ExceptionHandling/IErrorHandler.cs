using Microsoft.Extensions.Logging;

namespace PaperlessRestService.BusinessLogic.ExceptionHandling
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex, ILogger logger);
    }
}
