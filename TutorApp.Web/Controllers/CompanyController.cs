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
    public class CompanyController : Controller
    {
        // GET: Company
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

        public ActionResult _CompanyDetailtable(string Search, int? pageNo)
        {
            CompanyDetailSearchViewModel model = new CompanyDetailSearchViewModel();
            model.Search = Search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = CompanyDetailServices.Instance.GetCompanyDetailsCount(Search);
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails(Search, pageNo.Value);

            if (model.CompanyDetail != null)
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
        public ActionResult _Create(CompanyDetails CompanyDetail)
        {

            CompanyDetailServices.Instance.SaveCompanyDetails(CompanyDetail);
            return RedirectToAction("_CompanyDetailtable");
        }

        [HttpGet]
        public ActionResult _Edit(int ID)
        {

            return PartialView(CompanyDetailServices.Instance.GetCompanyDetail(ID));
        }
        [HttpPost]
        public ActionResult _Edit(CompanyDetails CompanyDetail)
        {

            CompanyDetailServices.Instance.UpdateCompanyDetails(CompanyDetail);
            return RedirectToAction("_CompanyDetailtable");
        }

        [HttpGet]
        public ActionResult _Delete(int ID)
        {
            var CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetail(ID);
            return RedirectToAction("_CompanyDetailtable");
        }
        [HttpPost]
        public ActionResult _Delete(CompanyDetails CompanyDetail)
        {
            CompanyDetailServices.Instance.DeleteCompanyDetails(CompanyDetail.ID);
            return RedirectToAction("_CompanyDetailtable");
        }
    }
}