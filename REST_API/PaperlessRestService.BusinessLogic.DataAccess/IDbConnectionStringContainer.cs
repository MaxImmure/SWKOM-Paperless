using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess
{
    /// <summary>
    /// Object that holds a connection string
    /// </summary>
    public interface IDbConnectionStringContainer
    {
        string GetConnectionString();
    }
}
