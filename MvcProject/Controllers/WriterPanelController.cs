using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id =0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading", "WriterPanel");
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


        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
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
            ViewBag.cv = categoryvalue;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            p.WriterId = 1;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.ctg = category;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetById(id);
            heading.HeadingStatus = false;
            hm.HeadingDelete(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p = 1)
        {
            var allheading = hm.GetList().ToPagedList(p, 4);
            return View(allheading);
        }
    }
}