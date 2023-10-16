﻿
namespace PaperlessRestService.BusinessLogic.DataAccess
{
    public class DbConnectionStringContainer : IDbConnectionStringContainer
    {
        public DbConnectionStringContainer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        private readonly string connectionString;
    }
}
