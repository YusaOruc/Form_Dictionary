using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManeger contentManeger = new ContentManeger(new EFContentDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValue = contentManeger.GetListByIDBL(id);
            return View(contentValue);
        }
        public ActionResult GetAllContent(string p)
        {
            
            if (p != null)
            {
                var values = contentManeger.GetListSerch(p);
                return View(values);
            }
            else
            {
                var values = contentManeger.GetListBL();
                return View(values);
            }
            
           
            
        }
    }
}