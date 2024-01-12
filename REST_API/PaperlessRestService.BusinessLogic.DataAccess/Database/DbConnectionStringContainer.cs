
using PaperlessRestService.BusinessLogic.DataAccess.Options;

namespace PaperlessRestService.BusinessLogic.DataAccess.Database
{
    public class DbConnectionStringContainer : IDbConnectionStringContainer
    {
        public DbConnectionStringContainer(DatabaseOptions options)
        {
            this.connectionString =
                $"Host={options.Host};Port={options.Port};Database={options.Database};Username={options.Username};Password={options.Password}";
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        private readonly string connectionString;
    }
}
