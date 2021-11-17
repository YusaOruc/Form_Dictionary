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
    [AllowAnonymous]
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        
        CategoryManeger categoryManeger = new CategoryManeger(new EFCategoryDal());
        [Authorize(Roles="B")]
        public ActionResult Index()
        {
            var categoryValues = categoryManeger.GetListBL();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid) { categoryManeger.AddBL(p); return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManeger.GetByIDBL(id);
            categoryManeger.DeleteBL(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = categoryManeger.GetByIDBL(id);
            
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManeger.UpdateBL(category);
            return RedirectToAction("Index");
        }

    }
}