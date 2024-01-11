using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Tests.Mock
{
    internal class MockTagRepository : ITagRepository
    {
        public bool Add(Tag tag)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public Tag Get(int id)
        {
            return new Tag()
            {
                Id = id,
                Name = "TestTag"
            };
        }

        public List<Tag> GetAll()
        {
            return statischeDaten.ToList();
        }

        public bool Update(Tag tag)
        {
            return true;
        }

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
