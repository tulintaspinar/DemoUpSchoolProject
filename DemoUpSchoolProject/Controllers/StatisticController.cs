using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class StatisticController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            //referansların toplam sayısı
            ViewBag.v1 = db.TBL_Testimonial.Count();

            //istanbuldaki referans sayısı
            ViewBag.v2 = db.TBL_Testimonial.Where(x=>x.City=="İstanbul").Count();

            //Yazılım mühendisi haricindeki kişi sayısı
            ViewBag.v3 = db.TBL_Testimonial.Where(x => x.Profession != "Yazılım Mühendisi").Count();

            //şehri trabzon olan kişinin ismi
            ViewBag.v4 = db.TBL_Testimonial.Where(x => x.City == "Trabzon").Select(y => y.NameSurname).FirstOrDefault();

            //referansların ortalama maaşları
            ViewBag.v5 = db.TBL_Testimonial.Average(x => x.Balance);
            return View();
        }
    }
}