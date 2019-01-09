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
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.AdminCount = AccountServices.Instance.GetAccountsCount();
            model.JobsCount = JobsServices.Instance.GetJobsCount();
            model.InboxCount = InboxServices.Instance.GetInboxsCount();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }

        int items = 20;
        public ActionResult __BlogTable(string Search, int? pageNo)
        {
            BlogViewModel model = new BlogViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalrecords = BlogServices.Instance.GetBlogsCount(Search);
            model.Blogs = BlogServices.Instance.GetBlogs(Search, pageNo.Value);

            if (model.Blogs != null)
            {
                model.Pager = new Pager(totalrecords, pageNo, items);

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

            var model = new ListViewModel
            {
                //BlogCategories = BlogCategoryService.Instance.GetBlogcategs(),
                //Logins = LoginsService.Instance.Getadmin()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Create(NewBlogViewModels model)
        {

            var newblog = new Blogs
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                Imageurl = model.ImageUrl,
                Category = CourseServices.Instance.GetCourse(model.CategoryID),
                Category2 = CourseServices.Instance.GetCourse(model.Category2ID),
                Category3 = CourseServices.Instance.GetCourse(model.Category3ID),
                Category4 = CourseServices.Instance.GetCourse(model.Category4ID),
                Category5 = CourseServices.Instance.GetCourse(model.Category5ID),

                //Writer = BlogCategoryService.Instance.GetBlogcateg(model.CategoryID)
            };
            BlogServices.Instance.SaveBlogs(newblog);
            return RedirectToAction("_BlogTable");
        }
        [HttpGet]
        public ActionResult _Edit(int ID)
        {
            var blog = BlogServices.Instance.GetBlog(ID);

            var model = new NewBlogViewModels
            {
                ID = blog.ID,
                Name = blog.Name,
                Description = blog.Description,

                ImageUrl = blog.Imageurl,
                Date = blog.Date,
               
                CategoryID = blog.Category.ID,
                Category = CourseServices.Instance.GetCourses(),

                 Category2ID = blog.Category.ID,
                Category2 = CourseServices.Instance.GetCourses(),

                Category3ID = blog.Category.ID,
                Category3 = CourseServices.Instance.GetCourses(),

                Category4ID = blog.Category.ID,
                Category4 = CourseServices.Instance.GetCourses(),

                Category5ID = blog.Category.ID,
                Category5 = CourseServices.Instance.GetCourses(),

                WriterID = blog.Category.ID,
                //Writer = BlogCategoryService.Instance.GetBlogcategs()
            };
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _Edit(NewBlogViewModels model)
        {


            var blog = BlogServices.Instance.GetBlogdispose(model.ID);

            blog.Name = model.Name;
            blog.Description = model.Description;


            blog.Imageurl = model.ImageUrl;

            blog.Date = model.Date;


            blog.Category = CourseServices.Instance.GetCourse(model.CategoryID);
            blog.Category2 = CourseServices.Instance.GetCourse(model.Category2ID);
            blog.Category3 = CourseServices.Instance.GetCourse(model.Category3ID);
            blog.Category4 = CourseServices.Instance.GetCourse(model.Category4ID);
            blog.Category5 = CourseServices.Instance.GetCourse(model.Category5ID);

            //blog.Writer = BlogCategoryService.Instance.GetBlogcateg(model.CategoryID);

            BlogServices.Instance.UpdateBlog(blog);
            return RedirectToAction("_BlogTable");
        }

        [HttpPost]
        public ActionResult _Delete(Blogs Blog)
        {

            BlogServices.Instance.DeleteBlog(Blog.ID);
            return RedirectToAction("_BlogTable");
        }
 
    }
}