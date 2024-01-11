using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic
{
    public interface ISearchDocumentLogic
    {
        public IEnumerable<Document>? SearchDocument(string query);
    }
}
