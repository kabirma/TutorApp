using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class BannerServices
    {

        #region singleton
        public static BannerServices Instance
        {
            get
            {
                if (instance == null) instance = new BannerServices();
                return instance;
            }
        }
        private static BannerServices instance { get; set; }
        private BannerServices()
        {

        }

        #endregion
        public void SaveBanner(Banners banner)
        {

            using (var context = new dbContext())
            {

                context.BannerTable.Add(banner);
                context.SaveChanges();
            }
        }

        public List<Banners> GetBanners(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.BannerTable.Where(CompanyDetail => CompanyDetail.Name != null && CompanyDetail.Name.ToLower().Contains(Search.ToLower())).OrderBy(CompanyDetail => CompanyDetail.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    return context.BannerTable.OrderBy(CompanyDetail => CompanyDetail.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
            }
        }
        public List<Banners> GetBanners()
        {
            using (var context = new dbContext())
            {
                return context.BannerTable.ToList();
            }
        }

        public int GetBannerCount()
        {
            using (var context = new dbContext())
            {
                return context.BannerTable.Count();
            }
        }

        public int GetBannerCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.BannerTable.Where(a => a.Name != null && a.Name.ToLower().Contains(Search.ToLower())).Count();
                }
                else
                {
                    return context.BannerTable.Count();
                }
            }
        }


        public Banners GetBanner(int ID)
        {
            using (var context = new dbContext())
            { return context.BannerTable.Find(ID); }
        }

        public void UpdateBanner(Banners Banner)
        {

            using (var context = new dbContext())
            {
                context.Entry(Banner).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteBanner(int ID)
        {
            using (var context = new dbContext())
            {
                var Banner = context.BannerTable.Find(ID);

                context.BannerTable.Remove(Banner);

                context.SaveChanges();

            }
        }
    }
}
