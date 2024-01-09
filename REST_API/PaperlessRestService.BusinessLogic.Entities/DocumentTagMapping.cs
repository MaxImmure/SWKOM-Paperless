using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    [Table("DocumentTagMapping")]
    public class DocumentTagMapping
    {
        [Required]
        public int TagId { get; set; }

        [Required]
        public int DocumentId { get; set; }
    }
}
