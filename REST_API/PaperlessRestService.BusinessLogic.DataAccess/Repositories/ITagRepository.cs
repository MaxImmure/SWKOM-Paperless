using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.DataAccess.Repositories
{
    public interface ITagRepository
    {
        Tag Get(int id);
        List<Tag> GetAll();

        bool Add(Tag tag);
        bool Update(Tag tag);
        bool Delete(int id);
    }
}
