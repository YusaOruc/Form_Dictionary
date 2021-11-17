using BusinessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManeger adminManeger = new AdminManeger(new EFAdminDal());
        AdminWriterManeger adminWriterManeger = new AdminWriterManeger(new EFAdminWriterDal());
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            
            var adminValues = adminManeger.GetAdmin(admin);
            if (adminValues != null)
            {
                FormsAuthentication.SetAuthCookie(adminValues.AdminName,false);
                Session["AdminName"] = adminValues.AdminName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

           
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var writerValues = adminWriterManeger.GetWriter(writer);
            if (writerValues != null)
            {
                FormsAuthentication.SetAuthCookie(writerValues.WriterMail, false);
                Session["WriterMail"] = writerValues.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }

    }
}