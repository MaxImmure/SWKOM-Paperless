

namespace PaperlessRestService.BusinessLogic
{
    using PaperlessRestService.BusinessLogic.Entities;
    public interface IDocumentCRUDLogic
    {
        Document GetDocument(int docId);
        bool DeleteDocument(int docId);
    }
}