using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Tests
{
    public class CRUDDocumentLogicTests
    {
        public CRUDDocumentLogicTests()
        {
            logicComponent = new DocumentCRUDLogic();
        }

        [Fact]
        public void DeleteDocument_WithEmptyId()
        {
            Document documentTest = new();

            bool result = logicComponent.DeleteDocument(0);

            Assert.True(result);
        }

        [Fact]
        public void GetDocument_WithId()
        {
            Document result = logicComponent.GetDocument(1);

            Assert.NotNull(result);
        }

        IDocumentCRUDLogic logicComponent;
    }
}