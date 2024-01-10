using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Minio.DataModel.Args;
using PaperlessRestService.BusinessLogic.DataAccess;
using PaperlessRestService.BusinessLogic.DataAccess.MinIO;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.ExceptionHandling;
using PaperlessRestService.BusinessLogic.Repositories;

namespace PaperlessRestService.BusinessLogic
{
    public class UploadDocumentLogic : IUploadDocumentLogic
    {
        public UploadDocumentLogic(
            DALActionExcecuterMiddleware dalActionExecuter,
            RabbitmqQueueOCRJob job,
            IMinioRepository minio_connection,
            IDocumentRepository documentRepository)
        {
            this.dalActionExecuter = dalActionExecuter;
            this.rabbitmq_connection = job;
            this.documentRepository = documentRepository;
            this.minio = minio_connection;
        }

        public bool UploadDocument(Document document)
        {
            try
            {
                bool successful = dalActionExecuter.Execute<bool>(() =>
                {
                    return documentRepository.InsertDocument(document);
                });

                //ToDo check if document already exists!
                //var alreadyExists = minio.FileExistsAsync(document.Original_File_Name).Result;
                var alreadyExists = false;

                if (successful && !alreadyExists)
                {
                    return QueueDocument(document) && ExportDocumentToFileStorage(document);
                }
            }
            catch (Exception ex)
            {
                throw new BLException("Fehler beim queuen des Documents", ex);
            }

            return false;
        }

        private bool QueueDocument(Document document)
        {
            try
            {
                rabbitmq_connection.Send("paperless/" + document.Original_File_Name, document.Title);
            }
            catch(Exception ex)
            {
                throw new BLException("RABBITMQ: Fehler beim queuen des Documents", ex);
            }

            return true;
        }

        private bool ExportDocumentToFileStorage(Document document)
        {
            try
            {
                minio.UploadFileAsync(new MemoryStream(document.Data), "paperless/" + document.Original_File_Name);
            }
            catch (Exception ex)
            {
                throw new BLException("MINIO: Fehler beim speichern des Documents", ex);
            }

            return true;
        }

        private readonly DALActionExcecuterMiddleware dalActionExecuter;
        private RabbitmqQueueOCRJob rabbitmq_connection;
        private readonly IDocumentRepository documentRepository;
        private IMinioRepository minio;
    }
}
