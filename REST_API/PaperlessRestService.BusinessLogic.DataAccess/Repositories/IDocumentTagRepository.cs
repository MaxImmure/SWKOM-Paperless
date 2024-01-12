using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.DataAccess.Repositories
{
    public interface IDocumentTagRepository
    {
        bool InsertTagForDocument(int docId, int tagId);
        bool DeleteTagForDocument(int docId, int tagId);
        Tag[] GetTagsForDocument(int docId);
    }
}
