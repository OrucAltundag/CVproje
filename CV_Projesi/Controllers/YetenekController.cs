using CV_Proje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Proje.Repositories;

namespace CV_Proje.Controllers
{
    public class YetenekController : Controller
    {
        dbCVEntities db = new dbCVEntities();
        GenericRepository<TBL_YETENEKLER> repo = new GenericRepository<TBL_YETENEKLER>();

        // GET: Yetenek
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBL_YETENEKLER p)
        {

            repo.TAdd(p);
            return RedirectToAction("Index");

        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.find(x => x.ID == id);
            repo.Tdelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.find(x => x.ID == id);
            return View(yetenek);

        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TBL_YETENEKLER t)
        {
            var y = repo.find(x => x.ID == t.ID);
          y.Yetenek=t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}