using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class InboxServices
    {


        #region singleton
        public static InboxServices Instance
            {
                get
                {
                    if (instance == null) instance = new InboxServices();
                    return instance;
                }
            }
            private static InboxServices instance { get; set; }
            private InboxServices()
            {

            }
            #endregion



            public List<Inbox> GetInboxs()
            {
                using (var context = new dbContext())
                {
                    return context.InboxTable.ToList();
                }
            }

            public int GetInboxsCount()
            {
                using (var context = new dbContext())
                {
                    return context.InboxTable.Count();
                }
            }

            public Inbox GetInbox(int ID)
            {
                using (var context = new dbContext())
                {
                    return context.InboxTable.Find(ID);
                }
            }

            public void SaveInbox(Inbox Inbox)
            {
                using (var context = new dbContext())
                {
                    context.InboxTable.Add(Inbox);
                    context.SaveChanges();
                }
            }

            public void UpdateInbox(Inbox Inboxs)
            {
                using (var context = new dbContext())
                {
                    context.Entry(Inboxs).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }

            public void DeleteInbox(int ID)
            {
                using (var context = new dbContext())
                {
                    var Inbox = context.InboxTable.Find(ID);
                    context.InboxTable.Remove(Inbox);
                    context.SaveChanges();
                }
            }


            public List<Inbox> GetInboxs(string Search, int pageNo)
            {
                int items = 3;
                using (var context = new dbContext())
                {
                    if (!string.IsNullOrEmpty(Search))
                    {
                        return context.InboxTable.Where(Inbox => Inbox.Name != null && Inbox.Name.ToLower().Contains(Search.ToLower())).OrderBy(Inbox => Inbox.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                    }
                    else
                    {
                        List<Inbox> Inbox = context.InboxTable.OrderBy(inbox => inbox.ID).Skip((pageNo - 1) * items).Take(items).ToList();

                        return Inbox;
                    }
                }
            }

            public int GetInboxsCount(string Search)
            {
                using (var context = new dbContext())
                {
                    if (!string.IsNullOrEmpty(Search))
                    {
                        int count = context.InboxTable.Where(Inbox => Inbox.Name != null && Inbox.Name.ToLower().Contains(Search.ToLower())).Count();
                        return count;
                    }
                    else
                    {
                        return context.InboxTable.Count();
                    }
                }
            }


        }
}
