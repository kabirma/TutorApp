using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class Questions : BaseEntity
    {
        public string Description { get; set; }
        public Students Askedby { get; set; }
        public string Date { get; set; }
        public Courses Subject { get; set; }
    }
}
