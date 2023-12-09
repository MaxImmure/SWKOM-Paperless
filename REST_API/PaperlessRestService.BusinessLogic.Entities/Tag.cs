using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    /// <summary>
    /// Tag for Documents
    /// </summary>
    [Table("Tags")]
    public class Tag
    {
        /// <summary>
        /// Unique indentifier for tag
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Color
        /// </summary>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Gets or Sets IsInboxTag
        /// </summary>
        [Required]
        public bool IsInboxTag { get; set; }

        /// <summary>
        /// Gets or Sets Match
        /// </summary>
        public string Match { get; set; }

        /// <summary>
        /// Gets or Sets MatchingAlgorithm
        /// </summary>
        public int? MatchingAlgorithm { get; set; }


        /// <summary>
        /// Gets or Sets IsInsensitive
        /// </summary>
        public bool? IsInsensitive { get; set; }

        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        public int? OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
