using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Entities
{
    public interface INote
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public Document Document { get; set; }
        public User user { get; set; }

    }
}
