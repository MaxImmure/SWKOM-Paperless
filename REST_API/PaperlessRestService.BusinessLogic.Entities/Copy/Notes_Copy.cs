using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Entities
{
    public class Notes_Copy
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public int Document { get; set; }
        public int User { get; set; }
    }
}
