
namespace PaperlessRestService.BusinessLogic.Tests
{
    using PaperlessRestService.BusinessLogic.DataAccess;
    using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
    using PaperlessRestService.BusinessLogic.Entities;
    using PaperlessRestService.BusinessLogic.Interfaces.Components;
    using PaperlessRestService.BusinessLogic.Tests.Mock;

    public class TagCRUDTests
    {
        public TagCRUDTests()
        {
            ITagRepository tagRepository = new MockTagRepository();
            DALActionExecuterMiddleware dalExecuter = new DALActionExecuterMiddleware();

            tagLogic = new TagCRUDLogic(tagRepository, dalExecuter);
        }

        [Fact]
        public void GetTags()
        {
            List<Tag> tags = tagLogic.GetTags();

            Assert.NotNull(tags);
        }

        [Fact]
        public void GetTag()
        {
            int tagId = 1;

            Tag tag = tagLogic.GetTag(tagId);

            Assert.NotNull(tag);
        }

        [Fact]
        public void AddTag()
        {
            Tag tag = new Tag()
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
            };

            bool result = tagLogic.Create(tag);

            Assert.True(result);
        }

        [Fact]
        public void RemoveTag()
        {
            int tagIdToRemove = 1;

            bool result = tagLogic.Delete(tagIdToRemove);

            Assert.True(result);
        }

        [Fact]
        public void UpdateTag()
        {
            Tag tag = new Tag()
            {
                Id = 1,
                Name = "Testtag 1",
                Color = "#FF2222",
                IsInboxTag = false,
                Match = "Testtag 1",
                MatchingAlgorithm = 0,
                IsInsensitive = false,
                OwnerId = 0,
                Owner = null,
            };

            bool result = tagLogic.Update(tag);

            Assert.True(result);
        }

        private ITagCRUDLogic tagLogic;
    }
}
