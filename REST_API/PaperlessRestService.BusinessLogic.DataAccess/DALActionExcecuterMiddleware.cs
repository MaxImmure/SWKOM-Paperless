using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess
{
    public class DALActionExcecuterMiddleware
    {
        public T Execute<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (NoRowChangedException ex)
            {
                throw new DALException("The database change resulted in 0 row changes.", ex);
            }
            catch (Exception ex)
            {
                throw new DALException($"Error while executing Action of", ex);
            }
        }

        public void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (NoRowChangedException ex)
            {
                throw new DALException("The database change resulted in 0 row changes.", ex);
            }
            catch (Exception ex)
            {
                throw new DALException($"Error while executing Action of", ex);
            }
        }
    }
}
