using Microsoft.EntityFrameworkCore;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.DataAccess
{
    public class PaperlessDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Correspondents> Correspondents { get; set; }

        public DbSet<Notes> Notes { get; set; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        public PaperlessDbContext(DbContextOptions<PaperlessDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureDocuments(ModelBuilder modelBuilder)
        {
            // ToDo David
        }

        private void ConfigureDocumentTyp(ModelBuilder modelBuilder)
        {
            // ToDo David
        }

        private void ConfigureCorrespondents(ModelBuilder modelBuilder)
        {
            // ToDo David
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            // ToDo David
        }

        private void ConfigureGroup(ModelBuilder modelBuilder)
        {
            // ToDo David
        }

        private void ConfigurePermission(ModelBuilder modelBuilder)
        {
            // ToDo David
        }
    }
}
