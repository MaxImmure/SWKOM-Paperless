using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperlessRestService.BusinessLogic.DataAccess.Options;
using PaperlessRestService.Queue;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperlessRestService.ServiceAgents.Interfaces;

namespace PaperlessRestService.ServiceAgents
{
    public class QueueReceiver : QueueClient, IQueueReceiver
    {
        public event EventHandler<QueueReceivedEventArgs> OnReceived;

        private EventingBasicConsumer _consumer;
        private readonly ILogger<QueueReceiver> _logger;

        public QueueReceiver(IOptions<QueueOptions> options, ILogger<QueueReceiver> logger) : base(options.Value.ConnectionString, options.Value.QueueName)
        {
            _consumer = new EventingBasicConsumer(RabbitMqChannel);
            _logger = logger;
        }

        public void StartReceive()
        {
            _logger.LogInformation("Starting Queue Consumer");

            _consumer.Received += (ch, ea) =>
            {
                try
                {
                    // received message  
                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var guid = Guid.Parse(ea.BasicProperties.CorrelationId);

                    _logger.LogInformation($"Received message {guid}");

                    // handle the received message  
                    HandleMessage(content, guid);
                    RabbitMqChannel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error while processing message {ea.BasicProperties.CorrelationId}");

                    // Message processing failed, retry a certain number of times with delays
                    int retries = 3;
                    int delayMilliseconds = 1000;

                    if (ea.BasicProperties.Headers == null)
                        ea.BasicProperties.Headers = new Dictionary<string, object>();

                    if (!ea.BasicProperties.Headers.ContainsKey("retry-count"))
                        ea.BasicProperties.Headers.Add("retry-count", 0);

                    int retryCount = (int)ea.BasicProperties.Headers["retry-count"];

                    if (retryCount < retries)
                    {
                        _logger.LogError($"Retrying #{retryCount} message {ea.BasicProperties.CorrelationId} in {delayMilliseconds}ms");
                        // Increase retry count and delay message requeue
                        ea.BasicProperties.Headers["retry-count"] = retryCount + 1;
                        ea.BasicProperties.Expiration = (delayMilliseconds * (retryCount + 1)).ToString();

                        RabbitMqChannel.BasicReject(ea.DeliveryTag, requeue: true);
                    }
                    else
                    {
                        _logger.LogError($"Sending message {ea.BasicProperties.CorrelationId} to the Dead-Letter Exchange");
                        // Message reached maximum retries, send it to the Dead-Letter Exchange
                        RabbitMqChannel.BasicReject(ea.DeliveryTag, requeue: false);
                    }
                }
            };

            _consumer.Shutdown += OnConsumerShutdown;
            _consumer.Registered += OnConsumerRegistered;
            _consumer.Unregistered += OnConsumerUnregistered;
            _consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            RabbitMqChannel.BasicConsume(queue: QueueName, autoAck: false, consumer: _consumer);
        }

        public void StopReceive()
        {
            _logger.LogInformation("Stopping Queue Consumer");

            foreach (var tag in _consumer.ConsumerTags)
            {
                RabbitMqChannel.BasicCancel(tag);
            }
            RabbitMqChannel.Close();
            RabbitMqChannel.Dispose();
            RabbitMqConnection.Close();
            RabbitMqConnection.Dispose();
        }

        private void HandleMessage(string content, Guid guid)
        {
            OnReceived?.Invoke(this, new QueueReceivedEventArgs(content, guid));
        }


        private void OnConsumerConsumerCancelled(object? sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerUnregistered(object? sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerRegistered(object? sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerShutdown(object? sender, ShutdownEventArgs e)
        {
        }
    }
}
