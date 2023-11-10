using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;

namespace PaperlessRestService.Queue
{
    public class RabbitmqQueueOptions : IRabbitmqQueueOptions
    {
        public const string Queue = "Queue";

        public RabbitmqQueueOptions(string ConnectionString, string QueueName)
        {
            this.ConnectionString = ConnectionString;
            this.QueueName = QueueName;
        }

        public RabbitmqQueueOptions()
        {
            this.ConnectionString = string.Empty;
            this.QueueName = string.Empty;
        }


        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }


}
