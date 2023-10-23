using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperlessRestService.BusinessLogic.Entities
{
    public class Document_Copy
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        public int[] Tags { get; set; } //Should be an array? fixed size? (there should not be any dynamic size change of the tags array, array is fine)

        public DateTime Created { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Added { get; set; }
        public string Archive_Serial_Number { get; set; }
        public string Original_File_Name { get; set; }
        public string Archived_File_Name { get; set; }
        public int? Storage_Path { get; set; }
        public bool User_Can_Change { get; set; }

        public Correspondents? Correspondent { get; set; } //Correspondent as Object?
        public DocumentType? Document_Type { get; set; }
        public User Owner { get; set; }
        public Notes[] notes { get; set; }
    }
}
