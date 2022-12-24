using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class SkillController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        [Authorize]
        public ActionResult Index()
        {
            var values = db.TBL_Feature.ToList();
            return View(values);
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddSkill(TBL_Feature feature)
        {
            db.TBL_Feature.Add(feature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DeleteSkill(int id)
        {
            var skill = db.TBL_Feature.Find(id);
            db.TBL_Feature.Remove(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize]
        public ActionResult UpdateSkill(int id)
        {
            var values = db.TBL_Feature.Find(id);
            return View(values);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateSkill(TBL_Feature feature)
        {
            var skill = db.TBL_Feature.Find(feature.ServicesFeatureID);
            skill.Title = feature.Title;
            skill.Description=feature.Description;
            skill.Value=feature.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}