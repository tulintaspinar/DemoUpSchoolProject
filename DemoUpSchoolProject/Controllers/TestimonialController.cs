using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class TestimonialController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        [Authorize]
        public ActionResult Index()
        {
            var values = db.TBL_Testimonial.ToList();
            return View(values);
        }
        [Authorize][HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [Authorize][HttpPost]
        public ActionResult AddTestimonial(TBL_Testimonial testimonial)
        {
            db.TBL_Testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = db.TBL_Testimonial.Find(id);
            db.TBL_Testimonial.Remove(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = db.TBL_Testimonial.Find(id);
            return View(testimonial);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateTestimonial(TBL_Testimonial _testimonial)
        {
            var testimonial = db.TBL_Testimonial.Find(_testimonial.TestimonialID);
            testimonial.NameSurname = _testimonial.NameSurname;
            testimonial.City = _testimonial.City;
            testimonial.Profession = _testimonial.Profession;
            testimonial.Email = _testimonial.Email;
            testimonial.Description = _testimonial.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}