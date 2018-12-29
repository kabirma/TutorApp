using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class ListViewModel
    {
      
        public List<Teachers> Writer { get; set; }

        public List<Courses> Courses { get; set; }
    }
}