using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Options;
using PaperlessRestService.BusinessLogic.DataAccess.Options;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.DataAccess.ElasticSearch
{
    public class ElasticSearchIndex : ISearchIndex
    {
        private readonly Uri _uri;
        private readonly ILogger<ElasticSearchIndex> _logger;

        public ElasticSearchIndex(IOptions<ElasticSearchOptions> options, ILogger<ElasticSearchIndex> logger)
        {
            this._uri = new Uri(options.Value.ConnectionString);
            this._logger = logger;
        }
        public void AddDocumentAsync(Document document)
        {
            var elasticClient = new ElasticsearchClient(_uri);

            if (!elasticClient.Indices.Exists("documents").Exists)
                elasticClient.Indices.Create("documents");

            var indexResponse = elasticClient.Index(document, "documents");
            if (!indexResponse.IsSuccess())
            {
                // Handle errors
                _logger.LogError($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");

                throw new Exception($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");
            }


        }

        public IEnumerable<Document> SearchDocumentAsync(string searchTerm)
        {
            var elasticClient = new ElasticsearchClient(_uri);

            var searchResponse = elasticClient.Search<Document>(s => s
                .Index("documents")
                .Query(q => q.QueryString(qs => qs.DefaultField(p => p.Content).Query($"*{searchTerm}*")))
            );

            return searchResponse.Documents;
        }
    }

}
