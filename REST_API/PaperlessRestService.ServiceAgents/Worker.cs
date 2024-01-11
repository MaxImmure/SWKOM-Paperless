using System.Runtime.CompilerServices;
using System.Threading;
using Elastic.Clients.Elasticsearch;
using Microsoft.EntityFrameworkCore;
using PaperlessRestService.BusinessLogic.DataAccess.Database;
using PaperlessRestService.BusinessLogic.DataAccess.ElasticSearch;
using PaperlessRestService.BusinessLogic.DataAccess.MinIO;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.ServiceAgents.Interfaces;
using PaperlessRestService.ServiceAgents.Interfaces.OCRLibrary;

namespace PaperlessRestService.ServiceAgents
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IQueueReceiver _queueReceiver;
        private readonly IOcrServiceArgent _ocrAgent;
        private readonly ISearchIndex _elasticAgent;
        private readonly IMinioRepository _minioAgent;
        private readonly PaperlessDbContext _dbAgent;

        public Worker(IQueueReceiver queueReceiver, IMinioRepository minioAgent,IOcrServiceArgent ocrAgent, ISearchIndex elasticAgent, PaperlessDbContextFactory db, ILogger<Worker> logger)
        {
            _logger = logger;
            _queueReceiver = queueReceiver;
            _ocrAgent = ocrAgent;  
            _elasticAgent = elasticAgent;
            _minioAgent = minioAgent;
            _dbAgent = db.Create();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker is starting.");

            _queueReceiver.OnReceived += HandleQueueMessage;
            _queueReceiver.StartReceive();

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker is stopping.");
            
            _queueReceiver.StopReceive();

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public void HandleQueueMessage(object? sender, QueueReceivedEventArgs e)
        {
            var fileStream = _minioAgent.GetFileAsync("paperless/"+e.Content).Result;
            var documentContent = _ocrAgent.OcrPdf(fileStream);
            Document doc = _dbAgent.Documents
                .Include(d => d.TagsMapping)
                .Where(d => d.Original_File_Name == e.Content)
                .First();
            doc.Content = documentContent;
            _elasticAgent.AddDocumentAsync(doc);
            _dbAgent.Documents.Update(doc);
            _dbAgent.SaveChanges();
        }
    }
}