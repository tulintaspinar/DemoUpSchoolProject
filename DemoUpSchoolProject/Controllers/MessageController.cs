using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class MessageController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Inbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TBL_Message.Where(x => x.ReceiverMail == mail).ToList();
            return View(values);
        }
        public ActionResult Outbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TBL_Message.Where(x => x.SenderMail == mail).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(TBL_Message message)
        {
            var mail = Session["MemberMail"].ToString();
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.SenderMail = mail;
            message.SenderNameSurname = db.TBL_Member.Where(x => x.MemeberMail == mail).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            message.ReceiverNameSurname = db.TBL_Member.Where(x => x.MemeberMail == message.ReceiverMail).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            db.TBL_Message.Add(message);
            db.SaveChanges();
            return RedirectToAction("Outbox");
        }
        public ActionResult MessageDetails()
        {
            return View();
        }
    }
}