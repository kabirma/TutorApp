using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApp.Entities;
using TutorApp.Services;
using TutorApp.Web.ViewModels;

namespace TutorApp.Web.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.AdminCount = AccountServices.Instance.GetAccountsCount();
            return View(model);
        }

        int items = 20;
        public ActionResult _FileTable(string Search, int? pageNo)
        {
            FileSearchViewModel model = new FileSearchViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = FilesServices.Instance.GetFilesCount(Search);
            model.File = FilesServices.Instance.GetFiles(Search, pageNo.Value);

            if (model.File != null)
            {
                model.Pager = new Pager(totalrecords, pageNo, items);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult _Create()
        {

            var model = new ListViewModel
            {
                FileCategory = FileCategServices.Instance.GetFilesCategory(),
                Teacher = TeachersServices.Instance.GetTeachers()

            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewFileViewModels model)
        {

            var newFile = new Files
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                FilePath=model.FilePath,
                Category = FileCategServices.Instance.GetFileCateg(model.CategoryID),
                Writer = TeachersServices.Instance.GetTeacher(model.WriterID)
            };
            FilesServices.Instance.SaveFiles(newFile);
            return RedirectToAction("_FileTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var File = FilesServices.Instance.GetFile(ID);

            var model = new NewFileViewModels
            {
                ID = File.ID,
                Name = File.Name,
                Description = File.Description,
                Date = File.Date,
                FilePath=File.FilePath,

                CategoryID = File.Category.ID,
                Category = FileCategServices.Instance.GetFilesCategory(),

                WriterID = File.Writer.ID,
                Writer = TeachersServices.Instance.GetTeachers()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewFileViewModels model)
        {


            var File = FilesServices.Instance.GetFiledispose(model.ID);

            File.Name = model.Name;
            File.Description = model.Description;

            File.Date = model.Date;
            File.FilePath = model.FilePath;

            File.Writer = TeachersServices.Instance.GetTeacher(model.WriterID);
            File.Category = FileCategServices.Instance.GetFileCateg(model.CategoryID);


            FilesServices.Instance.UpdateFile(File);
            return RedirectToAction("_FileTable");
        }

        [HttpPost]
        public ActionResult _Delete(Files File)
        {

            FilesServices.Instance.DeleteFile(File.ID);
            return RedirectToAction("_FileTable");
        }


    }
}