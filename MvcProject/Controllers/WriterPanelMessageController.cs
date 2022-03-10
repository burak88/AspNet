using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult InBox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInBox(p);
            return View(messagelist);
        }

        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendBox(p);
            return View(messagelist);
        }

        public PartialViewResult MessageLeftMenuPartial()
        {
            return PartialView();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string mail = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.Sender = mail;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }

            return View();
        }
    }
}