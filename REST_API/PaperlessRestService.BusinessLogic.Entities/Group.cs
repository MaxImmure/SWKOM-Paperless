using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaperlessRestService.BusinessLogic.Entities
{
    [Table("Groups")]
    public class Group
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<PermissionGroupMapping> Permissions { get; set; }
    }
}
