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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminAuthorizationManeger maneger = new AdminAuthorizationManeger(new EFAdminDal());
        public ActionResult Index()
        {
            var values = maneger.GetListBL();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            maneger.AddBL(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var Value = maneger.GetByIDBL(id);

            return View(Value);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            maneger.UpdateBL(admin);
            return RedirectToAction("Index");
        }


    }
}