using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorApp.Web.Helper
{
    public static class URLHelper
    {
        /**************** Shared *****************/
        public static string Imageuploader(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Shared",
                action = "UploadImage",
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /********************* Account **********************/
        public static string AccountTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "_AccountTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateAccount(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditAccount(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteAccount(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /*********************** Courses ***************************/

        public static string CoursesTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Coursestable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateCourses(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditCourse(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteCourse(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /******************* Course Field **********************/

        public static string CourseFieldTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_CourseFieldTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateCourseField(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditCourseField(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteCourseField(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }


    }
}