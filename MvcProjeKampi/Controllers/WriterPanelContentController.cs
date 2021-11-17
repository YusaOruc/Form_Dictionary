using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManeger contentManeger = new ContentManeger(new EFContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
           
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValue = contentManeger.GetListByWriterIDBL(writerIdInfo);
            return View(contentValue);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p)
                .Select(y => y.WriterID).FirstOrDefault();
            content.WriterID = writerIdInfo;
            content.ContentStatus = true;
            content.ContentDate =DateTime.Parse(DateTime.Now.ToShortDateString());

            contentManeger.AddBL(content);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}