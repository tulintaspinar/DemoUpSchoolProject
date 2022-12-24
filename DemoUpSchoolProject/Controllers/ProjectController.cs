using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class ProjectController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TBL_PROJECT.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TBL_PROJECT project)
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProject(TBL_PROJECT project)
        {
            return View();
        }
        public ActionResult DeleteProject(int id)
        {
            return View();
        }
    }
}