using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManeger headingManeger = new HeadingManeger(new EFHeadingDal());
        CategoryManeger categoryManeger = new CategoryManeger(new EFCategoryDal());
        WriterManeger  writerManeger = new WriterManeger(new EFWriterDal());
        Context context = new Context();
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfil(int id=0)
        {
            string deger = (string)Session["WriterMail"];
            ViewBag.de = deger;
            id = context.Writers.Where(x => x.WriterMail == deger).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = writerManeger.GetByIDBL(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfil(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManeger.UpdateBL(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManeger.GetListByWriter(writerIdInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valueCategory = (from x in categoryManeger.GetListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valueCategory;
           
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string deger = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == deger).Select(y => y.WriterID).FirstOrDefault();

            heading.HeadigDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerIdInfo;
            heading.HeadingStatus = true;
            headingManeger.AddBL(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManeger.GetByIDBL(id);
            if (headingValue.HeadingStatus == false) { headingValue.HeadingStatus = true; }
            else { headingValue.HeadingStatus = false; }

            headingManeger.DeleteBL(headingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headings = headingManeger.GetListBL().ToPagedList(p,4); ;
            return View(headings);
        }


    }
}