namespace PaperlessRestService.BusinessLogic.DataAccess.Database
{
    using Microsoft.EntityFrameworkCore;
    using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;

    /// <summary>
    /// Use this Factory to instantiate a new DbContext
    /// DbContext is like a unit of work. Every transaction should have its own DbContext
    /// </summary>
    public class PaperlessDbContextFactory
    {
        public PaperlessDbContextFactory(IDbConnectionStringContainer connectionStringContainer)
        {
            this.connectionStringContainer = connectionStringContainer;
        }

        public PaperlessDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaperlessDbContext>();
            optionsBuilder.UseNpgsql(connectionStringContainer.GetConnectionString());
            return new PaperlessDbContext(optionsBuilder.Options);
        }

        private readonly IDbConnectionStringContainer connectionStringContainer;
    }
}
