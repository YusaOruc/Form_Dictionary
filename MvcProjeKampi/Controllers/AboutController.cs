using BusinessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManeger aboutManeger = new AboutManeger(new EFAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManeger.GetListBL();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManeger.AddBL(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}