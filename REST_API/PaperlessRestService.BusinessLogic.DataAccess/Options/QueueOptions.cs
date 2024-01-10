using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess.Options
{
    public class QueueOptions
    {
        public const string Queue = "Queue";
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
