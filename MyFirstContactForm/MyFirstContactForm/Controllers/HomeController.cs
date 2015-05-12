using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstContactForm.Models; //life is easier if we import the models namespace

namespace MyFirstContactForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //do a quick test to make sure our insert works
            //ContactForm contactForm = new ContactForm(0, "dustin", "dustin@seedpaths.com", "test", DateTime.Now);
            //ContactFormDataAccess.InsertContactForm(contactForm);



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactForm contactForm)
        {
            ContactFormDataAccess.InsertContactForm(contactForm);
            return View("ThankYou");
        }
    }
}