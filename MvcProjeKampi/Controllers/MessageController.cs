using BusinessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManeger messageManeger = new MessageManeger(new EFMessageDal());
        MessageValidator validationRules = new MessageValidator();
        
        // GET: Message
        public ActionResult Inbox()
        {
            string p = (string)Session["AdminName"];
            var messageValues = messageManeger.GetListInboxBL(p);
            //ViewBag.Inbox = messageManeger.GetListInboxBL().Count();
            return View(messageValues);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminName"];
            var messageValues = messageManeger.GetListSendBL(p);
           

            return View(messageValues);
        }
        public ActionResult GetSendboxDetails(int id)
        {
            var contactValues = messageManeger.GetByIDBL(id);
            return View(contactValues);

        }
       
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string p = (string)Session["AdminName"];
            ValidationResult result = validationRules.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = p;
                message.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManeger.AddBL(message);
                return RedirectToAction("Sendbox");
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
        //public ActionResult Listeleme()
        //{
            
        //}
    }
}