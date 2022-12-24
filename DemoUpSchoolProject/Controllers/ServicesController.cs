using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        /*
            ToList
            Add
            Remove
            Where
         */
        UpSchoolDbPortfolioEntities portfolioEntities = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var values = portfolioEntities.TBL_Services.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TBL_Services tbl_Services)
        {
            portfolioEntities.TBL_Services.Add(tbl_Services);
            portfolioEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteServices(int id)
        {
            var values = portfolioEntities.TBL_Services.Find(id);
            portfolioEntities.TBL_Services.Remove(values);
            portfolioEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = portfolioEntities.TBL_Services.Find(id);

            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(TBL_Services services)
        {
            var values = portfolioEntities.TBL_Services.Find(services.ServicesID);
            values.Title = services.Title;
            portfolioEntities.SaveChanges();
            return RedirectToAction("Index","Services");
        }
    }
}