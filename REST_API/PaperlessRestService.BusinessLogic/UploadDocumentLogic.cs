using Microsoft.Extensions.DependencyInjection;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic
{
    public class UploadDocumentLogic : IUploadDocumentLogic
    {
        private RabbitmqQueueOCRJob rabbitmq_connection;

        public UploadDocumentLogic(RabbitmqQueueOCRJob job)
        {
            this.rabbitmq_connection = job;
            //minio
        }

        public bool UploadDocument(Document document)
        {
            Guid id = Guid.NewGuid();
            return QueueDocument(document, id) && ExportDocumentToFileStorage(document, id);
        }

        private bool QueueDocument(Document document, Guid id)
        {
            rabbitmq_connection.Send(document.Title, id); //ToDo Title gegen Path in MinIO ersetzen!
            return true;
        }

        private bool ExportDocumentToFileStorage(Document document, Guid id)
        {
            return false; //ToDo MinIO Integration
        }

        
    }
}
