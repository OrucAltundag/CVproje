using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Proje.Models.Entity;
using CV_Proje.Repositories;

namespace CV_Proje.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TBL_HOBILERIM> repo = new GenericRepository<TBL_HOBILERIM>();
        [HttpGet] // Bu metod sayfa yüklendiğinde çalışır.
        public ActionResult Index()
        {
            var hobiler = repo.List();      // Veritabanından tüm hobileri getirir.
            return View(hobiler);   // Elde edilen hobiler listesi View'e gönderilir.
        }
        // Hobilerin güncellenmesi için POST metodu.
        [HttpPost] // Form gönderildiğinde çalışır.
        public ActionResult Index(List<TBL_HOBILERIM> hobiler)
        {

            // Kullanıcıdan gelen hobiler listesini döngüyle işliyor.
            foreach (var p in hobiler)
            {
                // Güncellenecek hobiyi ID'sine göre buluyor.
                var hobi = repo.find(x => x.ID == p.ID);

                // Kullanıcıdan gelen yeni Aciklama1 değerini mevcut hobinin Aciklama1 alanına atıyor.
                hobi.Aciklama1 = p.Aciklama1;

                // Kullanıcıdan gelen yeni Aciklama2 değerini mevcut hobinin Aciklama2 alanına atıyor.
                hobi.Aciklama2 = p.Aciklama2;

                // Güncellenen hobiyi veritabanında kaydetmek için repo'daki TUpdate metodunu çağırıyor.
                repo.TUpdate(hobi);
            }

            // İşlem tamamlandıktan sonra Index action'ına yönlendiriyor.
            return RedirectToAction("Index");

        }
    }
}