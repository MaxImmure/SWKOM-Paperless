using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.ExceptionHandling;
using PaperlessRestService.BusinessLogic.Repositories;

namespace PaperlessRestService.BusinessLogic
{
    public class UploadDocumentLogic : IUploadDocumentLogic
    {
        public UploadDocumentLogic(
            RabbitmqQueueOCRJob job,
            IDocumentRepository documentRepository)
        {
            this.rabbitmq_connection = job;
            this.documentRepository = documentRepository;
            //minio
        }

        public bool UploadDocument(Document document)
        {
            Guid id = Guid.NewGuid();

            try
            {
                bool successful = documentRepository.InsertDocument(document);

                if (successful)
                {
                    return QueueDocument(document, id) && ExportDocumentToFileStorage(document, id);
                }
            }
            catch (Exception ex)
            {
                throw new BLException("Fehler beim queuen des Documents", ex);
            }

            return false;
        }

        private bool QueueDocument(Document document, Guid id)
        {
            try
            {
                rabbitmq_connection.Send(document.Title, id); //ToDo Title gegen Path in MinIO ersetzen!
            }
            catch(Exception ex)
            {
                throw new BLException("Fehler beim queuen des Documents", ex);
            }

            return true;
        }

        private bool ExportDocumentToFileStorage(Document document, Guid id)
        {
            return false; //ToDo MinIO Integration
        }

        private RabbitmqQueueOCRJob rabbitmq_connection;
        private readonly IDocumentRepository documentRepository;
    }
}
