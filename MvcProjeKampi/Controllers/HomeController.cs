using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        
        Context c = new Context();
        public ActionResult Index()
        {
            Category category = new Category();
            ViewBag.deneme = c.Categories.Count(x => x.CategoryStatus==true);
            ViewBag.yazilim = c.Headings.Where(x => x.CategoryID == 6).Count();
            ViewBag.yazar = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            int toplam = 0;
            int deger = 0;
            
            for (int i = 0; i < c.Categories.Count(); i++)
            {

                if(toplam < c.Headings.Where(x => x.CategoryID == i).Count())
                {
                    toplam = c.Headings.Where(x => x.CategoryID == i).Count();
                    deger = i;
                }

            }
            var a = c.Categories.SingleOrDefault(x => x.CategoryID == deger);
            ViewBag.baslik =a.CategoryName;

            ViewBag.tablo = (c.Categories.Where(x => x.CategoryStatus == true).Count()) - (c.Categories.Where(x => x.CategoryStatus == false).Count());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}