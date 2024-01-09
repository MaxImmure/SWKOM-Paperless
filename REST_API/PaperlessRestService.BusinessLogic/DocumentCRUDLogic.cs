
namespace PaperlessRestService.BusinessLogic
{
    using PaperlessRestService.BusinessLogic.DataAccess;
    using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
    using PaperlessRestService.BusinessLogic.Entities;

    public class DocumentCRUDLogic : IDocumentCRUDLogic
    {
        public DocumentCRUDLogic(IDocumentTagRepository documentTagRepository, DALActionExcecuterMiddleware dalExecuter)
        {
            this.documentTagRepository = documentTagRepository;
            this.dalExecuter = dalExecuter;
        }

        public bool DeleteDocument(int docId)
        {
            return false;
        }

        public Document GetDocument(int docId)
        {
            return null;
        }

        public bool AddTagToDocument(int docId, int tagId)
        {
            return dalExecuter.Execute<bool>(() =>
            {
                return documentTagRepository.InsertTagForDocument(docId, tagId);
            });
        }

        public bool RemoveTagFromDocument(int docId, int tagId)
        {
            return dalExecuter.Execute<bool>(() =>
            {
                return documentTagRepository.DeleteTagForDocument(docId, tagId);
            });
        }

        public Tag[] GetTagsForDocument(int docId)
        {
            return dalExecuter.Execute<Tag[]>(() =>
            {
                return documentTagRepository.GetTagsForDocument(docId);
            });
        }

        private readonly IDocumentTagRepository documentTagRepository;
        private readonly DALActionExcecuterMiddleware dalExecuter;
    }
}