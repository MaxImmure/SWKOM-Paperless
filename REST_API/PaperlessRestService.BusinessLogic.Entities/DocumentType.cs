using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    [Table("DocumentTypes")]
    public class DocumentType
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Slug { get; set; }

        [Required]
        public string Name { get; set; }
        public string Match { get; set; }

        public int? MatchingAlgorithm { get; set; }

        public bool? IsInsensitive { get; set; }

        public int Document_Count { get; set; }

        public int? Owner { get; set; }

    }
}
