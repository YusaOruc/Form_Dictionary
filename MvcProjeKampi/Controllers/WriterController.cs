using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManeger writerManeger = new WriterManeger(new EFWriterDal());
        WriterValidator validationRules = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var WriterValues = writerManeger.GetListBL();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManeger.AddBL(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {

            var writerValue = writerManeger.GetByIDBL(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManeger.UpdateBL(writer);
                return RedirectToAction("Index");
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
    }
}