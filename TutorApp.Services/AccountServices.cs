using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Entities;
using TutorApp.Database;

namespace TutorApp.Services
{
    #region singleton

    public class AccountServices
    {
      
            public static AccountServices Instance
            {
                get
                {
                    if (instance == null) instance = new AccountServices();
                    return instance;
                }
            }
            private static AccountServices instance { get; set; }
            private AccountServices()
            {

            }
        #endregion

      

        public List<Accounts> GetAccounts()
        {
         using(var context=new dbContext())
            {
                return context.AccountTable.ToList();
            }
        }

        public int GetAccountsCount()
        {
            using (var context = new dbContext())
            {
                return context.AccountTable.Count();
            }
        }

        public Accounts GetAccount(int ID)
        {
            using (var context = new dbContext())
            {
                return context.AccountTable.Find(ID);
            }
        }

        public void SaveAccount(Accounts account)
        {
            using (var context = new dbContext())
            {
                context.AccountTable.Add(account);
                context.SaveChanges();
            }
        }

        public void UpdateAccount(Accounts accounts)
        {
            using (var context = new dbContext())
            {
                context.Entry(accounts).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteAccount(int ID)
        {
            using (var context = new dbContext())
            {
                var account = context.AccountTable.Find(ID);
                context.AccountTable.Remove(account);
                context.SaveChanges();
            }
        }


        public List<Accounts> GetAccounts(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.AccountTable.Where(Account => Account.Name != null && Account.Name.ToLower().Contains(Search.ToLower())).OrderBy(Account => Account.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    List<Accounts> account= context.AccountTable.OrderBy(Account => Account.ID).Skip((pageNo - 1) * items).Take(items).ToList();

                    return account;
                }
            }
        }

        public int GetAccountsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    int count= context.AccountTable.Where(Account => Account.Name != null && Account.Name.ToLower().Contains(Search.ToLower())).Count();
                    return count;
                }
                else
                {
                    return context.AccountTable.Count();
                }
            }
        }

    }

}
