using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ProjectImages/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                project.ProjectImage = "ProjectImages/" + dosyaAdi;
            }
            db.TBL_PROJECT.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TBL_PROJECT.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TBL_PROJECT project)
        {
            var value = db.TBL_PROJECT.Find(project.ProjectID);
            value.ProjectName = project.ProjectName;
            value.ProjectImage = project.ProjectImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            db.TBL_PROJECT.Remove(db.TBL_PROJECT.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}