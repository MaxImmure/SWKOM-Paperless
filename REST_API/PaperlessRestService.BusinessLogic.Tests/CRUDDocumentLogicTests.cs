using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.Repositories;
using PaperlessRestService.BusinessLogic.Tests.Mock;

namespace PaperlessRestService.BusinessLogic.Tests
{
    public class CRUDDocumentLogicTests
    {
        public CRUDDocumentLogicTests()
        {
            IDocumentRepository documentRepository = new MockDocumentRepository();
            IDocumentTagRepository documentTagRepository = new MockDocumentTagRepository();

            logicComponent = new DocumentCRUDLogic(documentTagRepository, documentRepository, new DataAccess.DALActionExcecuterMiddleware());
        }

        [Fact]
        public void DeleteDocument_WithEmptyId()
        {
            bool result = logicComponent.DeleteDocument(0);

            Assert.True(result);
        }

        [Fact]
        public void GetDocument_WithId()
        {
            Document result = logicComponent.GetDocument(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void AddTagToDocument_WithEmptyTagId()
        {
            bool result = logicComponent.AddTagToDocument(1, 0);

            Assert.True(result);
        }

        [Fact]
        public void AddTagToDocument_WithEmptyDocId()
        {
            bool restult = logicComponent.AddTagToDocument(0, 1);
        }

        [Fact]
        public void GetTagFromDocument_WithEmptyId()
        {
            Tag[] result = logicComponent.GetTagsForDocument(0);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetTagFromDocument_WithId()
        {
            Tag[] result = logicComponent.GetTagsForDocument(1);

            Assert.NotNull(result);
        }

        IDocumentCRUDLogic logicComponent;
    }
}