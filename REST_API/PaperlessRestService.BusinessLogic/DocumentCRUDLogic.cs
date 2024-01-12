
namespace PaperlessRestService.BusinessLogic
{
    using PaperlessRestService.BusinessLogic.DataAccess;
    using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
    using PaperlessRestService.BusinessLogic.Entities;
    using PaperlessRestService.BusinessLogic.Repositories;

    public class DocumentCRUDLogic : IDocumentCRUDLogic
    {
        public DocumentCRUDLogic(IDocumentTagRepository documentTagRepository, IDocumentRepository documentRepository, DALActionExecuterMiddleware dalExecuter)
        {
            this.documentTagRepository = documentTagRepository;
            this.documentRepository = documentRepository;
            this.dalExecuter = dalExecuter;
        }

        public bool DeleteDocument(int docId)
        {
            return dalExecuter.Execute<bool>(() =>
            {
                return documentRepository.DeleteDocument(docId);
            });
        }

        public Document GetDocument(int docId)
        {
            return dalExecuter.Execute<Document>(() =>
            {
                return documentRepository.GetDocument(docId);
            });
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
        private readonly IDocumentRepository documentRepository;
        private readonly DALActionExecuterMiddleware dalExecuter;
    }
}