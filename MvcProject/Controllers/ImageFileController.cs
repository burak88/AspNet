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
    public class ImageFileController : Controller
    {
        // GET: ImageFile
        ImageFileManager ıfm = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = ıfm.GetList();
            return View(files);
        }
    }
}