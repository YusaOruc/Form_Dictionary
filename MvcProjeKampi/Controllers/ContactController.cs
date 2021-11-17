using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        MessageManeger messageManeger = new MessageManeger(new EFMessageDal());
        ContactManeger contactManeger = new ContactManeger(new EFContactDal());
        ContactValidator validationRules = new ContactValidator();
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            var contactValues = messageManeger.GetListBL();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = messageManeger.GetByIDBL(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}