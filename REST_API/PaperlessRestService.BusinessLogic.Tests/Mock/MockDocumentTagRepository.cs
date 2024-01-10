using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
using PaperlessRestService.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Tests.Mock
{
    internal class MockDocumentTagRepository : IDocumentTagRepository
    {
        public bool DeleteTagForDocument(int docId, int tagId)
        {
            throw new NotImplementedException();
        }

        public Tag[] GetTagsForDocument(int docId)
        {
            throw new NotImplementedException();
        }

        public bool InsertTagForDocument(int docId, int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
