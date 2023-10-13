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
        public void DeleteDocument_WithNullId()
        {
            Document documentTest = new();

            bool result = logicComponent.DeleteDocument();

            Assert.False(result);
        }

        IDocumentCRUDLogic logicComponent;
    }
}