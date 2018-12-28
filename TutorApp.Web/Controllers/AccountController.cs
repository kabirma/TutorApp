using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApp.Entities;
using TutorApp.Services;
using TutorApp.Database;
using TutorApp.Web.ViewModels;

namespace TutorApp.Web.Controllers.Admin
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
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

       

     
        [HttpPost]
        public ActionResult _Delete(Accounts account)
        {

            AccountServices.Instance.DeleteAccount(account.ID);
            return RedirectToAction("_AccountTable");
        }




        /*********** End****************/
    }
}