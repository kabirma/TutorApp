using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class Blogs : BaseEntity
    {
        public string Description { get; set; }
        public Teachers Writer { get; set; }
        public string Date { get; set; }
        public string Imageurl { get; set; }
        public Courses Category { get; set; }
        public Courses Category2 { get; set; }
        public Courses Category3 { get; set; }
        public Courses Category4 { get; set; }
        public Courses Category5 { get; set; }
    }
}
