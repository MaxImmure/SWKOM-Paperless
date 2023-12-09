using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Interfaces.Components
{
    public interface ITagCRUDLogic
    {
        bool Create(Tag tag);
        bool Update(Tag tag);
        bool Delete(int tagId);
        Tag GetTag(int tagId);
        List<Tag> GetTags();
    }
}
