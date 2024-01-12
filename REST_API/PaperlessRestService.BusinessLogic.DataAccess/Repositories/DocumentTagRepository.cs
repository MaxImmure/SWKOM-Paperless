using Microsoft.EntityFrameworkCore;
using PaperlessRestService.BusinessLogic.DataAccess.Database;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.DataAccess.Repositories
{
    public class DocumentTagRepository : IDocumentTagRepository
    {
        public DocumentTagRepository(PaperlessDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public bool DeleteTagForDocument(int docId, int tagId)
        {
            using PaperlessDbContext dbContext = dbContextFactory.Create();

            DocumentTagMapping? documentTag = dbContext.DocumentTagMappings.FirstOrDefault(d => d.DocumentId == docId && d.TagId == tagId);
            if (documentTag == null)
            {
                throw new Exception("The DocumentTagMapping was not found.");
            }

            dbContext.DocumentTagMappings.Remove(documentTag);
            int delta = dbContext.SaveChanges();

            if (delta > 0)
            {
                return true;
            }
            else
            {
                throw new NoRowChangedException();
            }
        }

        public Tag[] GetTagsForDocument(int docId)
        {
            using PaperlessDbContext dbContext = dbContextFactory.Create();

            int[] tagIds = dbContext.DocumentTagMappings
                .Where(d => d.DocumentId == docId)
                .Select(d => d.TagId)
                .ToArray();

            if (tagIds.Length == 0)
            {
                return Array.Empty<Tag>();
            }

            Tag[] tags = dbContext.Tags.Where(t => tagIds.Contains(t.Id)).ToArray();

            return tags;
        }

        public bool InsertTagForDocument(int docId, int tagId)
        {
            using PaperlessDbContext dbContext = dbContextFactory.Create();

            DocumentTagMapping mapping = new()
            {
                DocumentId = docId,
                TagId = tagId
            };

            dbContext.DocumentTagMappings.Add(mapping);
            int delta = dbContext.SaveChanges();

            if (delta > 0)
            {
                return true;
            }
            else
            {
                throw new NoRowChangedException();
            }
        }

        private PaperlessDbContextFactory dbContextFactory;
    }
}
