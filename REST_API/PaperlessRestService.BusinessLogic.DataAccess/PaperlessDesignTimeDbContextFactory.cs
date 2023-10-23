using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PaperlessRestService.BusinessLogic.DataAccess
{
    public class PaperlessDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PaperlessDbContext>
    {
        public PaperlessDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaperlessDbContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Paperless;Username=postgres;Password=postgres");

            return new PaperlessDbContext(optionsBuilder.Options);
        }
    }
}
