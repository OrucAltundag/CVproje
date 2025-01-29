using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Proje.Models.Entity;
using CV_Proje.Repositories;

namespace CV_Proje.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TBL_SOSYALMEDYA> repo = new GenericRepository<TBL_SOSYALMEDYA>();

        // GET: SosyalMedya
        public ActionResult Index()
        {
            var veriler = repo.List();

            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBL_SOSYALMEDYA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.find(x=>x.ID ==id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TBL_SOSYALMEDYA p)
        {
            var hesap = repo.find(x=> x.ID == p.ID);
            hesap.AD = p.AD;
            hesap.Durum = true;
            hesap.Link = p.Link;
            hesap.Icon = p.Icon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");   
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.find(x =>x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

    }
}