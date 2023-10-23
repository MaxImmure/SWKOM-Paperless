using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public List<GroupUserMapping> Groups { get; set; }
    }
}
