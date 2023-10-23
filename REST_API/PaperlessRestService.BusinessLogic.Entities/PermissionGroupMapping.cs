using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Entities
{
    /// <summary>
    /// Mapping table for permissions and groups
    /// </summary>
    [Table("PermissionGroupMappings")]
    public class PermissionGroupMapping
    {
        [Required]
        public int GroupId { get; set; }

        [Required]
        public string PermissionName { get; set; }
    }
}
