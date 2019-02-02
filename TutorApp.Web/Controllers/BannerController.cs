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
    public class BannerController : Controller
    {
        // GET: Banner
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.AdminCount = AccountServices.Instance.GetAccountsCount();
            model.JobsCount = JobsServices.Instance.GetJobsCount();
            model.InboxCount = InboxServices.Instance.GetInboxsCount();
            model.Banner = BannerServices.Instance.GetBanners();
            model.Inbox = InboxServices.Instance.GetInboxs();
            return View(model);
        }

        public ActionResult _Bannertable(string Search, int? pageNo)
        {
            BannerSearchViewModel model = new BannerSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = BannerServices.Instance.GetBannerCount(Search);
            model.Banner = BannerServices.Instance.GetBanners(Search, pageNo.Value);

            if (model.Banner != null)
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
        public ActionResult _Create(Banners Banner)
        {

            BannerServices.Instance.SaveBanner(Banner);
            return RedirectToAction("_Bannertable");
        }

        [HttpGet]
        public ActionResult _Edit(int ID)
        {

            return PartialView(BannerServices.Instance.GetBanner(ID));
        }
        [HttpPost]
        public ActionResult _Edit(Banners Banner)
        {

            BannerServices.Instance.UpdateBanner(Banner);
            return RedirectToAction("_Bannertable");
        }

        [HttpGet]
        public ActionResult _Delete(int ID)
        {
            var Banner = BannerServices.Instance.GetBanner(ID);
            return RedirectToAction("_Bannertable");
        }
        [HttpPost]
        public ActionResult _Delete(Banners Banner)
        {
            BannerServices.Instance.DeleteBanner(Banner.ID);
            return RedirectToAction("_Bannertable");
        }
    }
}