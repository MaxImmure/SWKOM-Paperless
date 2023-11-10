using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ
{
    public interface IRabbitmqQueueOptions
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
