using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorApp.Web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var filename = Guid.NewGuid() + Path.GetExtension(file.FileName);

                var path = Path.Combine(Server.MapPath("/Content/Database_Images/"), filename);
                file.SaveAs(path);
                result.Data = new { Success = true, ImageUrl = string.Format("/Content/Database_Images/{0}", filename) };
            }
            catch (Exception ex) { result.Data = new { Success = false, Message = ex.Message }; }
            return result;
        }


        public JsonResult UploadFile()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var filename = Guid.NewGuid() + Path.GetExtension(file.FileName);

                var path = Path.Combine(Server.MapPath("/Content/Files/"), filename);
                file.SaveAs(path);
                result.Data = new { Success = true, FileUrl = string.Format("/Content/Files/{0}", filename) };
            }
            catch (Exception ex) { result.Data = new { Success = false, Message = ex.Message }; }
            return result;
        }
    }
}