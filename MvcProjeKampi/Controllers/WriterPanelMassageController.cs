using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrate;
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
    public class WriterPanelMassageController : Controller
    {
        MessageManeger messageManeger = new MessageManeger(new EFMessageDal());
        MessageValidator validationRules = new MessageValidator();
       
        // GET: WriterPanelMassage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
           

            var messageValues = messageManeger.GetListInboxBL(p );
            //ViewBag.Inbox = messageManeger.GetListInboxBLp(p).Count();
            return View(messageValues);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageValues = messageManeger.GetListSendBL(p);


            return View(messageValues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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
            string p = (string)Session["WriterMail"];
            ValidationResult result = validationRules.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = p;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
    }
}