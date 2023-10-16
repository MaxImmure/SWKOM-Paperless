using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    [Table("Notes")]
    public class Notes
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public int User { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}
