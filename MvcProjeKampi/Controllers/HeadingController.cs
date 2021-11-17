using BusinessLayer.Concrate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManeger headingManeger = new HeadingManeger(new EFHeadingDal());
        CategoryManeger categoryManeger = new CategoryManeger(new EFCategoryDal());
        WriterManeger writerManeger = new WriterManeger(new EFWriterDal());

        // GET: Heading
        public ActionResult Index()
        {
            var HeadingValues = headingManeger.GetListBL();
            return View(HeadingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManeger.GetListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,Value=x.CategoryID.ToString()

                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in writerManeger.GetListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+" "+x.WriterSurName,
                                                      Value = x.WriterID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadigDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManeger.AddBL(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManeger.GetListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = headingManeger.GetByIDBL(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManeger.UpdateBL(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManeger.GetByIDBL(id);
            if (headingValue.HeadingStatus == false) { headingValue.HeadingStatus = true; }
            else { headingValue.HeadingStatus = false; }
            
            headingManeger.DeleteBL(headingValue);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingReport()
        {
            var HeadingValues = headingManeger.GetListBL();
            return View(HeadingValues);
        }

    }
}