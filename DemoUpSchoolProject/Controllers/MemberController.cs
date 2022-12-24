using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class MemberController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        [Authorize]
        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TBL_Member.Where(x=>x.MemeberMail== mail).FirstOrDefault();
            ViewBag.name = values.MemberName;
            ViewBag.surname = values.MemberSurname;
            ViewBag.id = values.MemberID;
            return View();
        }
        [HttpGet]
        public ActionResult UpdateMember()
        {
            var mail = Session["MemberMail"].ToString();
            var user = db.TBL_Member.Where(x => x.MemeberMail == mail).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateMember(TBL_Member member)
        {
            var user = db.TBL_Member.Where(x => x.MemberID == member.MemberID).FirstOrDefault();
            user.MemberName = member.MemberName;
            user.MemberSurname = member.MemberSurname;
            user.MemeberMail = member.MemeberMail;
            user.MemberPassword = member.MemberPassword;
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}