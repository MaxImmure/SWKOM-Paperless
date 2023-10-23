using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    [Table("PermissionNames")]
    public class PermissionName
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
