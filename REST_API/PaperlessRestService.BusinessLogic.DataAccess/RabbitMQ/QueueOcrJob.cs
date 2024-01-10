using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperlessRestService.BusinessLogic.DataAccess.Options;
using PaperlessRestService.Queue;
using RabbitMQ.Client;

namespace PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ
{
    public class QueueOcrJob : QueueClient, IQueueOCRJob
    {
        public QueueOcrJob(IOptions<QueueOptions> options) : base(options.Value.ConnectionString, options.Value.QueueName)
        { }

        public void Send(string body, string originalFilename)
        {
            IBasicProperties properties = base.RabbitMqChannel.CreateBasicProperties();
            properties.CorrelationId = originalFilename;

            base.RabbitMqChannel.BasicPublish(exchange: ExchangeName,
                routingKey: $"{QueueName}.*",
                mandatory: false,
                basicProperties: properties,
                body: System.Text.Encoding.UTF8.GetBytes(body));
        }
    }
}
