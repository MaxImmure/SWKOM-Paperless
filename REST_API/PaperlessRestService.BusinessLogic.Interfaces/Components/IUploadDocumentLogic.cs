using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic
{
    public interface IUploadDocumentLogic
    {
        public bool UploadDocument(Document document);
        public bool QueueDocument(Document document, Guid id);
        public bool ExportDocumentToFileStorage(Document document, Guid id);
    }
}
