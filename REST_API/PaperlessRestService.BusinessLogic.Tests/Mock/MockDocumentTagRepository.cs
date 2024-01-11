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
            if(docId == 0 || tagId == 0)
            {
                return false;
            }

            return true;
        }

        public Tag[] GetTagsForDocument(int docId)
        {
            DocumentTagMapping mapping = TagsMapping.FirstOrDefault(x => x.DocumentId == docId);

            if(mapping == null)
            {
                return Array.Empty<Tag>();
            }

            return statischeDaten.Where(x => x.Id == mapping.TagId).ToArray();
        }

        public bool InsertTagForDocument(int docId, int tagId)
        {
            if (docId == 0 || tagId == 0)
            {
                return false;
            }

            return true;
        }

        private static List<DocumentTagMapping> TagsMapping = new List<DocumentTagMapping>()
        {
            new DocumentTagMapping()
            {
                DocumentId = 1,
                TagId = 1
            },
            new DocumentTagMapping()
            {
                DocumentId = 1,
                TagId = 2
            },
        };

        private static Tag[] statischeDaten = new Tag[]
        {
            new Tag()
            {
                Id = 1,
                Name = "Testtag 1",
                Color = "#FF0000",
                IsInboxTag = false,
                Match = "Testtag 1",
                MatchingAlgorithm = 0,
                IsInsensitive = false,
                OwnerId = 0,
                Owner = null,
            },
            new Tag()
            {
                Id = 2,
                Name = "Testtag 1",
                Color = "#FF0000",
                IsInboxTag = false,
                Match = "Testtag 1",
                MatchingAlgorithm = 0,
                IsInsensitive = false,
                OwnerId = 0,
                Owner = null,
            }
        };
    }
}
