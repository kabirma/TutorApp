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
    public class InboxController : Controller
    {
        // GET: Inbox
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.AdminCount = AccountServices.Instance.GetAccountsCount();
            model.JobsCount = JobsServices.Instance.GetJobsCount();
            model.InboxCount = InboxServices.Instance.GetInboxsCount();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();

            model.Inbox = InboxServices.Instance.GetInboxs();
            return View(model);
        }
        public ActionResult _InboxTable(string Search, int? pageNo)
        {
            InboxSearchViewModel model = new InboxSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.Inbox = InboxServices.Instance.GetInboxs(Search, pageNo.Value);
            var totalrecords = InboxServices.Instance.GetInboxsCount(Search);


            if (model.Inbox != null)
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
        public ActionResult _Create(Inbox Inbox)
        {

            InboxServices.Instance.SaveInbox(Inbox);
            return RedirectToAction("_InboxTable");
        }



        [HttpPost]
        public ActionResult _Delete(Inbox Inbox)
        {

            InboxServices.Instance.DeleteInbox(Inbox.ID);
            return RedirectToAction("_InboxTable");
        }




        /*********** End****************/
    }
}