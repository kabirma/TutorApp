using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class Files : BaseEntity
    {
        public string Description { get; set; }
        public Teachers Writer { get; set; }
        public string Date { get; set; }
        public string FilePath { get; set; }
        public FilesCategory Category { get; set; }
    }
}
