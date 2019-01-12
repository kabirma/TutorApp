using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.Entities
{
    public class CompanyDetails : BaseEntity
    {
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Imageurl { get; set; }
        public string Description { get; set; }
        public string AboutImage { get; set; }
    }
}
