using Microsoft.Extensions.Logging;
using PaperlessRestService.BusinessLogic.DataAccess;
using PaperlessRestService.BusinessLogic.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic
{
    public sealed class BLActionExecuterMiddleware
    {
        public BLActionExecuterMiddleware(ILogger<BLActionExecuterMiddleware> logger)
        {
            this.logger = logger;
        }

        public T Execute<T>(Func<T> action)
        {
            if(action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw new BLException($"Error while executing Action of", ex);
            }
        }

        public void Execute(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                action();
            }
            catch (Exception ex)
            {
                BLException blException = new BLException($"Error while executing Action of", ex);
                errorHandler.HandleError(blException, logger);
                throw blException;
            }
        }

        private IErrorHandler errorHandler = new ErrorHandler();
        private readonly ILogger<BLActionExecuterMiddleware> logger;
    }
}
