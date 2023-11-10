using Microsoft.Extensions.DependencyInjection;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic
{
    public class UploadDocumentLogic : IUploadDocumentLogic
    {
        private IServiceProvider service;

        public UploadDocumentLogic(IServiceProvider service)
        {
            this.service = service;
        }

        public bool UploadDocument(Document document)
        {
            Guid id = Guid.NewGuid();
            return QueueDocument(document, id) && ExportDocumentToFileStorage(document, id);
        }

        public bool QueueDocument(Document document, Guid id)
        {
            var rabbitmq = service.GetService<RabbitmqQueueOCRJob>();
            rabbitmq.Send(document.Title, id);

            return true;
        }

        public bool ExportDocumentToFileStorage(Document document, Guid id)
        {
            return false;
        }
    }
}
