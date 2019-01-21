using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class VideoComments : BaseEntity
    {
        public string Comment { get; set; }
        public Videos Video { get; set; }
        public string Date { get; set; }
    }
}
