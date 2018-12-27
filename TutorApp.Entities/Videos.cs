using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class Videos : BaseEntity
    {
        public string Description { get; set; }
        public Teachers Writer { get; set; }
        public string Date { get; set; }
        public string FilePath { get; set; }
        public VideosCategory Category { get; set; }
    }
}
