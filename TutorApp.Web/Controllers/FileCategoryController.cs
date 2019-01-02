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
    public class FileCategoryController : Controller
    {
        // GET: FileCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _FileCategtable(string Search, int? pageNo)
        {
            FileCategSearchViewModel model = new FileCategSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = FileCategServices.Instance.GetFilesCategoryCount(Search);
            model.FileCateg = FileCategServices.Instance.GetFilesCategory(Search, pageNo.Value);

            if (model.FileCateg != null)
            {
                model.Pager = new Pager(totalrecords, pageNo, 3);

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
            return PartialView();
        }
        [HttpPost]
        public ActionResult _Create(FilesCategory FileCateg)
        {

            FileCategServices.Instance.SaveFilesCategory(FileCateg);
            return RedirectToAction("_FileCategtable");
        }

        [HttpGet]
        public ActionResult _Edit(int ID)
        {

            return PartialView(FileCategServices.Instance.GetFileCateg(ID));
        }
        [HttpPost]
        public ActionResult _Edit(FilesCategory FileCateg)
        {

            FileCategServices.Instance.UpdateFilesCategory(FileCateg);
            return RedirectToAction("_FileCategtable");
        }

        [HttpGet]
        public ActionResult _Delete(int ID)
        {
            var FileCateg = FileCategServices.Instance.GetFileCateg(ID);
            return RedirectToAction("_FileCategtable");
        }
        [HttpPost]
        public ActionResult _Delete(FilesCategory FileCateg)
        {
            FileCategServices.Instance.DeleteFilesCategory(FileCateg.ID);
            return RedirectToAction("_FileCategtable");
        }
    }
}