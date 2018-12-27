using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class Students :BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ZipCode { get; set; }
    }
}
