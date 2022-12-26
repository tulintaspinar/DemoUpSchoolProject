using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class LoginController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_Member member)
        {
            var values = db.TBL_Member.FirstOrDefault(x => x.MemeberMail == member.MemeberMail && x.MemberPassword == member.MemberPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.MemeberMail, false);
                Session["MemberMail"] = member.MemeberMail;
                return RedirectToAction("Index","About");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}