using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    public class Correspondents_Copy
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }

        public string Match { get; set; }
        public int MatchingAlgorithm { get; set; }
        public bool IsInsensitive { get; set; }

        // Foreign Key to What
        public int Owner { get; set; }

        public Correspondents LastCorrespondents { get; set; }
        public Permission View { get; set; }
        public Permission Change { get; set; }

    }
}