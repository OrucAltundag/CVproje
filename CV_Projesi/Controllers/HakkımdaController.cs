using CV_Proje.Models.Entity;       // Veritabanı varlıklarına erişim için.
using CV_Proje.Repositories;       // Generic Repository'yi kullanmak için.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;              // MVC framework'ü bileşenleri için.

namespace CV_Proje.Controllers
{
    // Hakkımda sayfasını yöneten controller.
    public class HakkımdaController : Controller
    {
        // Generic repository nesnesi oluşturuluyor. "TBL_HAKKINDA" tablosunu temsil ediyor.
        GenericRepository<TBL_HAKKINDA> repo = new GenericRepository<TBL_HAKKINDA>();

        // "Hakkımda" bilgilerini listelemek için GET metodu.
        [HttpGet]  // Sayfa yüklendiğinde çalışır.
        public ActionResult Index()
        {
            // Veritabanından tüm "Hakkımda" bilgilerini alır.
            var hakkında = repo.List();

            // Alınan veriler View'e gönderilir.
            return View(hakkında);
        }

        // "Hakkımda" bilgilerini güncellemek için POST metodu.
        [HttpPost] // Formdan gönderilen verileri işler.
        public ActionResult Index(TBL_HAKKINDA p)
        {
            // ID'si 1 olan "Hakkımda" kaydını bulur.
            // (Burada ID'nin sabit 1 olduğu varsayılmıştır.)
            var t = repo.find(x => x.ID == 1);

            // Formdan gelen yeni bilgilerle mevcut kayıt güncellenir.
            t.Ad = p.Ad;                  // Ad bilgisi güncelleniyor.
            t.Soyad = p.Soyad;            // Soyad bilgisi güncelleniyor.
            t.Adres = p.Adres;            // Adres bilgisi güncelleniyor.
            t.Mail = p.Mail;              // Mail bilgisi güncelleniyor.
            t.Telefon = p.Telefon;        // Telefon bilgisi güncelleniyor.
            t.Hakkında = p.Hakkında;      // Hakkında metni güncelleniyor.
            t.Resim = p.Resim;            // Resim URL'si güncelleniyor.

            // Güncellenmiş kayıt veritabanına kaydedilir.
            repo.TUpdate(t);

            // Güncelleme sonrası kullanıcı Index sayfasına yönlendirilir.
            return RedirectToAction("Index");
        }
    }
}