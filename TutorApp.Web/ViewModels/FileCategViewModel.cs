using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class FileCategSearchViewModel
    {
        public List<FilesCategory> FileCateg { get; set; }
        public string Search { get; internal set; }

        public Pager Pager { get; set; }
    }
}