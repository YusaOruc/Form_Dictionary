using BusinessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManeger imageFileManeger = new ImageFileManeger(new EFImageDal());
        public ActionResult Index()
        {
            var imageValues = imageFileManeger.GetListBL();
            return View(imageValues);
        }
    }
}