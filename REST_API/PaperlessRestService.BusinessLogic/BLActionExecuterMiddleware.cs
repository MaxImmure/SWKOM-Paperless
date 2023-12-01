using PaperlessRestService.BusinessLogic.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic
{
    public sealed class BLActionExecuterMiddleware
    {
        public T Execute<T>(Func<T> action)
        {
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
            try
            {
                action();
            }
            catch (BLException ex)
            {
                throw new DALException($"Error while executing Action of", ex);
            }
        }
    }
}
