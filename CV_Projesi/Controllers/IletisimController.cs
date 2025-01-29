using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Proje.Models.Entity;
using CV_Proje.Repositories;

namespace CV_Proje.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<TBL_ILETISIM> repo = new GenericRepository<TBL_ILETISIM>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}