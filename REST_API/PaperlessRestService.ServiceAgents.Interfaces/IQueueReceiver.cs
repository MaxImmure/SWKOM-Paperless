using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.ServiceAgents.Interfaces
{
    public interface IQueueReceiver
    {
        event EventHandler<QueueReceivedEventArgs> OnReceived;
        void StartReceive();
        void StopReceive();

    }
}
