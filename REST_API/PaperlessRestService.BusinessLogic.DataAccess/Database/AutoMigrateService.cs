using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess.Database
{
    public class AutoMigrateService
    {
        private readonly PaperlessDbContextFactory factory;

        public AutoMigrateService(PaperlessDbContextFactory factory)
        {
            this.factory = factory;
        }

        public void Migrate()
        {
            using PaperlessDbContext dbContext = factory.Create();

            dbContext.Database.Migrate();
        }
    }
}
