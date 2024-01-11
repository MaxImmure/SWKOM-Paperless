using PaperlessRestService.BusinessLogic.DataAccess.MinIO;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic.DataAccess;
using PaperlessRestService.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PaperlessRestService.BusinessLogic.DataAccess.ElasticSearch;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic
{
    public class SearchDocumentLogic : ISearchDocumentLogic
    {
        public SearchDocumentLogic(
            DALActionExcecuterMiddleware dalActionExecuter,
            ISearchIndex elasticSearchIndex,
            IDocumentRepository documentRepository)
        {
            this.dalActionExecuter = dalActionExecuter;
            this.elasticSearchIndex = elasticSearchIndex;
            this.documentRepository = documentRepository;
        }

        public IEnumerable<Document> SearchDocument(string query)
        {
            return dalActionExecuter.Execute<IEnumerable<Document>>(() =>
            {
                return elasticSearchIndex.SearchDocumentAsync(query);
            });
        }

        private readonly DALActionExcecuterMiddleware dalActionExecuter;
        private ISearchIndex elasticSearchIndex;
        private readonly IDocumentRepository documentRepository;
    }
}
