using PaperlessRestService.BusinessLogic.DataAccess;
using PaperlessRestService.BusinessLogic.DataAccess.Database;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        public DocumentRepository(PaperlessDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public bool DeleteDocument(int id)
        {
            using PaperlessDbContext dbContext = dbContextFactory.Create();

            Document found = dbContext.Documents.First(d => d.Id == id);

            if (found == null)
            {
                throw new Exception("Document was not found.");
            }

            dbContext.Documents.Remove(found);
            int delta = dbContext.SaveChanges();

            if (delta > 0)
            {
                return true;
            }

            throw new NoRowChangedException();
        }

        public bool InsertDocument(Document document)
        {
            using PaperlessDbContext dbContext = dbContextFactory.Create();

            dbContext.Documents.Add(document);

            int delta = dbContext.SaveChanges();

            if (delta > 0)
            {
                return true;
            }

            throw new NoRowChangedException();
        }

        public bool UpdateDocument(Document document)
        {
            using PaperlessDbContext dbContext = dbContextFactory.Create();

            dbContext.Documents.Update(document);

            int delta = dbContext.SaveChanges();

            if (delta > 0)
            {
                return true;
            }

            throw new NoRowChangedException();
        }

        private readonly PaperlessDbContextFactory dbContextFactory;
    }
}
