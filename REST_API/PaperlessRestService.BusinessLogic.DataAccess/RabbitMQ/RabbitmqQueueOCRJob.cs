using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperlessRestService.Queue;
using RabbitMQ.Client;

namespace PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ
{
    public class RabbitmqQueueOCRJob : RabbitmqQueueClient, IQueueOCRJob
    {
        public RabbitmqQueueOCRJob(IOptions<RabbitmqQueueOptions> options) : base(options.Value.ConnectionString, options.Value.QueueName)
        { }

        public void Send(string body, Guid documentId)
        {
            IBasicProperties properties = base.RabbitMqChannel.CreateBasicProperties();
            properties.CorrelationId = documentId.ToString();

            base.RabbitMqChannel.BasicPublish(exchange: ExchangeName,
                routingKey: $"{QueueName}.*",
                mandatory: false,
                basicProperties: properties,
                body: System.Text.Encoding.UTF8.GetBytes(body));
        }
    }
}
