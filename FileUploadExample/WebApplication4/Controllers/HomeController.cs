using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: recieve file upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {

            try
            {
                // get filename
                var filename = Guid.NewGuid().ToString().Substring(0, 5) + "_" +Path.GetFileName(file.FileName);
                var filenamePath = Path.Combine(Server.MapPath("~/Content/Uploads"), filename);
                file.SaveAs(filenamePath); // Saving the file
                // success
                ViewBag.Message = "File uploaded successfully";
            }
            catch (Exception e) {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}