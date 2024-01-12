using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.DataAccess.ElasticSearch
{
    public interface ISearchIndex
    {
        void AddDocumentAsync(Document doc);
        IEnumerable<Document> SearchDocumentAsync(string searchTerm);
    }

}
