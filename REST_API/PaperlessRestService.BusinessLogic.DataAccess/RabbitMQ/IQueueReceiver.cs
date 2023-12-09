using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ
{
    public interface IQueueReceiver
    {
        event EventHandler<QueueReceivedEventArgs> OnReceived;
        void StartReceive();
        void StopReceive();

    }
}
