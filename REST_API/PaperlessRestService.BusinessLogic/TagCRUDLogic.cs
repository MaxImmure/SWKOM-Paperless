using PaperlessRestService.BusinessLogic.DataAccess;
using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.Interfaces.Components;

namespace PaperlessRestService.BusinessLogic
{
    public sealed class TagCRUDLogic : ITagCRUDLogic
    {
        public TagCRUDLogic(ITagRepository tagRepository, DALActionExecuterMiddleware actionExcecuter)
        {
            this.tagRepository = tagRepository;
            this.actionExcecuter = actionExcecuter;
        }

        public List<Tag> GetTags()
        {
            return actionExcecuter.Execute<List<Tag>>(() =>
            {
                return tagRepository.GetAll();
            });
        }

        public Tag GetTag(int id)
        {
            return actionExcecuter.Execute<Tag>(() =>
            {
                return tagRepository.Get(id);
            });
        }

        public bool Create(Tag tag)
        {
            return actionExcecuter.Execute<bool>(() =>
            {
                return tagRepository.Add(tag);
            });
        }

        public bool Delete(int tagId)
        {
            return actionExcecuter.Execute<bool>(() =>
            {
                return tagRepository.Delete(tagId);
            });
        }

        public bool Update(Tag tag)
        {
            return actionExcecuter.Execute<bool>(() =>
            {
                return tagRepository.Update(tag);
            });
        }

        private readonly ITagRepository tagRepository;
        private readonly DALActionExecuterMiddleware actionExcecuter;
    }
}
