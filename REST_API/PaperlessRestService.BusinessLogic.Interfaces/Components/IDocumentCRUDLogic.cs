

namespace PaperlessRestService.BusinessLogic
{
    using PaperlessRestService.BusinessLogic.Entities;
    public interface IDocumentCRUDLogic
    {
        Document GetDocument(int docId);
        bool DeleteDocument(int docId);

        bool AddTagToDocument(int docId, int tagId);
        
        bool RemoveTagFromDocument(int docId, int tagId);
        
        Tag[] GetTagsForDocument(int docId);
    }
}