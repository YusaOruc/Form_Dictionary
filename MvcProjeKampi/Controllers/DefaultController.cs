using BusinessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManeger headingManeger = new HeadingManeger(new EFHeadingDal());
        ContentManeger contentManeger = new ContentManeger(new EFContentDal());
        public ActionResult Headings()
        {
            var headingList = headingManeger.GetListBL();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = contentManeger.GetListByWriterIDBL(id);
            return PartialView(contentList);
        }
    }
}