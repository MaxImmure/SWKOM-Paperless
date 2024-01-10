using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace PaperlessRestService.BusinessLogic.Entities
{
    [Table("Documents")]
    public class Document
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }

        public DateTime Created { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Added { get; set; }
        public string Archive_Serial_Number { get; set; }
        public string Original_File_Name { get; set; }
        public string Archived_File_Name { get; set; }
        public int? Storage_Path { get; set; }
        public bool User_Can_Change { get; set; }

        public byte[] Data { get; set; }

        public int? CorrespondentId { get; set; }
        public Correspondents? Correspondent { get; set; } //Correspondent as Object?
        
        public int? DocumentTypeId { get; set; }
        public DocumentType? Document_Type { get; set; }

        public int? OwnerId { get; set; }
        public User Owner { get; set; }

        [NotMapped]
        public int[] Tags => TagsMapping?.Select(t => t.TagId)?.ToArray();

        [JsonIgnore]
        public List<DocumentTagMapping> TagsMapping { get; set; }

        /// <summary>
        /// One to Many relationship with Notes
        /// </summary>
        public Notes[] notes { get; set; }
    }
}
