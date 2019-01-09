using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorApp.Database;
using TutorApp.Entities;

namespace TutorApp.Services
{
    public class CompanyDetailServices
    {

        #region singleton
        public static CompanyDetailServices Instance
        {
            get
            {
                if (instance == null) instance = new CompanyDetailServices();
                return instance;
            }
        }
        private static CompanyDetailServices instance { get; set; }
        private CompanyDetailServices()
        {

        }

        #endregion
        public void SaveCompanyDetails(CompanyDetails CompanyDetail)
        {

            using (var context = new dbContext())
            {

                context.CompanyDetailsTable.Add(CompanyDetail);
                context.SaveChanges();
            }
        }

        public List<CompanyDetails> GetCompanyDetails(string Search, int pageNo)
        {
            int items = 3;
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CompanyDetailsTable.Where(CompanyDetail => CompanyDetail.Name != null && CompanyDetail.Name.ToLower().Contains(Search.ToLower())).OrderBy(CompanyDetail => CompanyDetail.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
                else
                {
                    return context.CompanyDetailsTable.OrderBy(CompanyDetail => CompanyDetail.ID).Skip((pageNo - 1) * items).Take(items).ToList();
                }
            }
        }
        public List<CompanyDetails> GetCompanyDetails()
        {
            using (var context = new dbContext())
            {
                return context.CompanyDetailsTable.ToList();
            }
        }

        public int GetCompanyDetailsCount()
        {
            using (var context = new dbContext())
            {
                return context.CompanyDetailsTable.Count();
            }
        }

        public int GetCompanyDetailsCount(string Search)
        {
            using (var context = new dbContext())
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    return context.CompanyDetailsTable.Where(a => a.Name != null && a.Name.ToLower().Contains(Search.ToLower())).Count();
                }
                else
                {
                    return context.CompanyDetailsTable.Count();
                }
            }
        }


        public CompanyDetails GetCompanyDetail(int ID)
        {
            using (var context = new dbContext())
            { return context.CompanyDetailsTable.Find(ID); }
        }

        public void UpdateCompanyDetails(CompanyDetails CompanyDetails)
        {

            using (var context = new dbContext())
            {
                context.Entry(CompanyDetails).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCompanyDetails(int ID)
        {
            using (var context = new dbContext())
            {
                var CompanyDetails = context.CompanyDetailsTable.Find(ID);

                context.CompanyDetailsTable.Remove(CompanyDetails);

                context.SaveChanges();

            }
        }

    }
}
