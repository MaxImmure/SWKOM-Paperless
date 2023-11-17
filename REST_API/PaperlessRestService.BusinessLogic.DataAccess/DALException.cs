using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess
{
    public class DALException : Exception
    {
        public DALException(string message, Exception ex) :
            base(message, ex)
        {
        }
    }
}
