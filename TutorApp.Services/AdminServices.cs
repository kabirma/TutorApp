using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class AdminServices
    {
        #region singleton
        public static AdminServices Instance
        {
            get
            {
                if (instance == null) instance = new AdminServices();
                return instance;
            }
        }
        private static AdminServices instance { get; set; }
        private AdminServices()
        {

        }
        #endregion
        public Accounts Signin(Accounts Account)
        {
            using (var context = new dbContext())
            {
                Accounts check = context.AccountTable.Where(x => x.Email.Equals(Account.Email) && x.Password.Equals(Account.Password)).FirstOrDefault();
                return check;
            }
        }
    }
}
