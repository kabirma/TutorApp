using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorApp.Web.Helper
{
    public static class URLHelper
    {
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
    }
}