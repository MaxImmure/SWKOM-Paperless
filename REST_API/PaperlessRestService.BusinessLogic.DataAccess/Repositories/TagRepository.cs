using PaperlessRestService.BusinessLogic.DataAccess.Database;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.DataAccess.Repositories
{
    public class TagRepository : ITagRepository
    {
        public TagRepository(PaperlessDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public bool Add(Tag tag)
        {
            using PaperlessDbContext dbContext = contextFactory.Create();

            dbContext.Tags.Add(tag);

            int delta = dbContext.SaveChanges();

            if (delta < 1)
            {
                throw new NoRowChangedException();
            }

            return true;
        }

        public bool Delete(int id)
        {
            using PaperlessDbContext dbContext = contextFactory.Create();

            Tag found = dbContext.Tags.First(t => t.Id == id);
            dbContext.Tags.Remove(found);

            int delta = dbContext.SaveChanges();

            if (delta < 1)
            {
                throw new NoRowChangedException();
            }

            return true;
        }

        public Tag Get(int id)
        {
            using PaperlessDbContext dbContext = contextFactory.Create();

            Tag found = dbContext.Tags.First(t => t.Id == id);

            return found;
        }

        public bool Update(Tag tag)
        {
            using PaperlessDbContext dbContext = contextFactory.Create();

            dbContext.Tags.Update(tag);

            int delta = dbContext.SaveChanges();

            if (delta < 1)
            {
                throw new NoRowChangedException();
            }

            return true;
        }

        public List<Tag> GetAll()
        {
            using PaperlessDbContext dbContext = contextFactory.Create();

            return dbContext.Tags.ToList();
        }

        private readonly PaperlessDbContextFactory contextFactory;
    }
}
