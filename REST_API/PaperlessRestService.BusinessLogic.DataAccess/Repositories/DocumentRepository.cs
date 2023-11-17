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
            try
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

                throw new Exception("No Rows changed!");
            }
            catch (Exception ex)
            {
                throw new DALException("Error while trying to delete a document", ex);
            }
        }

        public bool InsertDocument(Document document)
        {
            try
            {
                using PaperlessDbContext dbContext = dbContextFactory.Create();

                dbContext.Documents.Add(document);

                int delta = dbContext.SaveChanges();

                if (delta > 0)
                {
                    return true;
                }

                throw new Exception("No Rows changed!");
            }
            catch(Exception ex)
            {
                throw new DALException("Error while trying to insert a document", ex);
            }
        }

        public bool UpdateDocument(Document document)
        {
            try
            {
                using PaperlessDbContext dbContext = dbContextFactory.Create();

                dbContext.Documents.Update(document);

                int delta = dbContext.SaveChanges();

                if (delta > 0)
                {
                    return true;
                }

                throw new Exception("No Rows changed!");
            }
            catch(Exception ex)
            {
                throw new DALException("Error while trying to update a document", ex);
            }
        }

        private readonly PaperlessDbContextFactory dbContextFactory;
    }
}
