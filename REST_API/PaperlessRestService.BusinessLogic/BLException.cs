using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic
{
    public class BLException : Exception
    {
        public BLException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
