using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class FileSearchViewModel
    {
        public List<Files> File { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }
    public class NewFileViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string FilePath { get; set; }
      


        public int CategoryID { get; set; }
        public List<FilesCategory> Category { get; set; }


        public int WriterID { get; set; }
        public List<Teachers> Writer { get; set; }

    }
}