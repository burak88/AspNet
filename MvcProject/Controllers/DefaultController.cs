using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingvalue = hm.GetList();
            return View(headingvalue);
        }
        public PartialViewResult Index(int id=0)
        {
            var value = cm.GetListByHeadingId(id);
            return PartialView(value);
        }
    }
}