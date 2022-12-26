using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class AboutController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        [Authorize]
        public ActionResult Index()
        {
            var values = db.TBL_About.ToList();
            return View(values);
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddAbout()
        {
            return View();
        } 
        [HttpPost]
        [Authorize]
        public ActionResult AddAbout(TBL_About about)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ProjectImages/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                about.ImageUrl = "ProjectImages/" + dosyaAdi;
            }
            db.TBL_About.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DeleteAbout(int id)
        {
            db.TBL_About.Remove(db.TBL_About.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize]
        public ActionResult UpdateAbout(int id)
        {
            var valuess = db.TBL_About.Find(id);
            return View(valuess);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateAbout(TBL_About about)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ProjectImages/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                about.ImageUrl = "ProjectImages/" + dosyaAdi;
            }
            var values = db.TBL_About.Find(about.AboutID);
            values.Description = about.Description;
            values.ImageUrl = about.ImageUrl;
            values.NameSurname = about.NameSurname;
            values.Title = about.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
