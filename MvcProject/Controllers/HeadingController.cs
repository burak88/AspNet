using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalue = hm.GetList();
            return View(headingvalue);
        }

        public ActionResult HeadingReport()
        {
            var headingvalue = hm.GetList();
            return View(headingvalue);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cgv = categoryvalue;

            List<SelectListItem> writervalue = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterLastName,
                                                    Value = x.WriterId.ToString()
                                                }
                                                ).ToList();
            ViewBag.wtv = writervalue;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.ctgry = categoryvalues;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingdel = hm.GetById(id);
            headingdel.HeadingStatus = false;
            hm.HeadingDelete(headingdel);
            return RedirectToAction("Index");
        }

    }


}