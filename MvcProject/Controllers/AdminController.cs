using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p )
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.UserName, false);
                Session["UserName"] = adminuserinfo.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail
            //&& x.WriterPassword == p.WriterPassword);
            var writeruserinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}