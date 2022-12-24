using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

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
            return PartialView();
        }
        public PartialViewResult ContactsPartial()
        {
            return PartialView();
        }
    }
}