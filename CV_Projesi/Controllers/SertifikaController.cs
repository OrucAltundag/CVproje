using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CV_Proje.Models.Entity;
using CV_Proje.Repositories;

namespace CV_Proje.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TBL_SERTIFIKALARIM> repo = new GenericRepository<TBL_SERTIFIKALARIM>();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
            
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TBL_SERTIFIKALARIM t)
        {
            var sertifika = repo.find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TBL_SERTIFIKALARIM t)
        { 
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.find(x => x.ID == id);
            repo.Tdelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}