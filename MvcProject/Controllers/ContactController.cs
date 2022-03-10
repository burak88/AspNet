using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact 
        ContactManager ctm = new ContactManager(new EfContactDal());
        ContactValidator contactvalidator = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalue = ctm.GetList();
            return View(contactvalue);
        }

        public ActionResult GetContactDetails(int id)
        {
            var valuedetails = ctm.GetById(id);
            return View(valuedetails);
        }
        public PartialViewResult LeftMenuPartial()
        {
            return PartialView();
        }
    }
}