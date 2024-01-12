using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PaperlessRestService.BusinessLogic.DataAccess.Database
{
    public class PaperlessDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PaperlessDbContext>
    {
        public PaperlessDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaperlessDbContext>();

            optionsBuilder.UseNpgsql(args[0]);

            return new PaperlessDbContext(optionsBuilder.Options);
        }
    }
}
