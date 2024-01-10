using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Tests.Mock
{
    internal class MockDocumentRepository : IDocumentRepository
    {
        public bool DeleteDocument(int id)
        {
            throw new NotImplementedException();
        }

        public Document GetDocument(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDocument(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
