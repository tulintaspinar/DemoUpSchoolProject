using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;
using Microsoft.Ajax.Utilities;

namespace DemoUpSchoolProject.Controllers
{
    public class UserController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AboutPartial()
        {
            var values = db.TBL_About.ToList();
            return PartialView(values);
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult ServicesPartial()
        {
            var values = db.TBL_Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult SkillsPartial()
        {
            var values = db.TBL_Feature.ToList();
            return PartialView(values);
        }
        public PartialViewResult TestimonialsPartial()
        {
            var values = db.TBL_Testimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult ProjectsPartial()
        {
            var values = db.TBL_PROJECT.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult ContactsPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ContactsPartial(TBL_Message message)
        {
            message.ReceiverMail = "tulin@gmail.com";
            message.ReceiverNameSurname = "Tülin Taşpınar";
            message.MessageDate = DateTime.Now;
            db.TBL_Message.Add(message);
            db.SaveChanges();
            return PartialView();
        }
    }
}