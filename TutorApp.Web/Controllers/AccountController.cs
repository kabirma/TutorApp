using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApp.Entities;
using TutorApp.Services;
using TutorApp.Web.ViewModels;

namespace TutorApp.Web.Controllers.Admin
{
    public class AccountController : Controller
    {
        // GET: Account
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
            model.Admin = AccountServices.Instance.GetAccounts().Where(x => x.Name == Session["username"].ToString()).ToList();
            return View(model);
        }
        public ActionResult _AccountTable(string Search, int? pageNo)
        {
            AccountSearchViewModel model = new AccountSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.Accounts = AccountServices.Instance.GetAccounts(Search, pageNo.Value);
            var totalrecords = AccountServices.Instance.GetAccountsCount(Search);
            

            if (model.Accounts != null)
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
        public ActionResult _Create(Accounts Account)
        {

            AccountServices.Instance.SaveAccount(Account);
            return RedirectToAction("_AccountTable");
        }



        [HttpPost]
        public ActionResult _Delete(Accounts account)
        {

            AccountServices.Instance.DeleteAccount(account.ID);
            return RedirectToAction("_AccountTable");
        }




        /*********** End****************/
    }
}