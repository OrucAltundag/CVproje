using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Proje.Models.Entity;

namespace CV_Proje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        dbCVEntities db = new dbCVEntities();



        public ActionResult Index()
        {

            var degerler = db.TBL_HAKKINDA.ToList();    // TBL_HAKKINDA tablosundaki verileri listeye alır.
            return View(degerler); // Verileri Index View'a gönderir.
        }
        public PartialViewResult SosyalMedya()
        {
            var SosyalMedya = db.TBL_SOSYALMEDYA.Where(x=>x.Durum==true).ToList();  // Durumu aktif olan sosyal medya verilerini alır.
            return PartialView(SosyalMedya); // Sosyal medya verilerini Partial View'a gönderir.
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TBL_DENEYIMLERIM.ToList(); // TBL_DENEYIMLERIM tablosundaki verileri listeye alır.
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.TBL_EGITIMLERIM.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yetenekler()
        {
            var yetenekler = db.TBL_YETENEKLER.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobiler()
        {
            var hobiler = db.TBL_HOBILERIM.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.TBL_SERTIFIKALARIM.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
           return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(TBL_ILETISIM t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());  // İletişim tarihini bugünün tarihi olarak ayarlar.
            db.TBL_ILETISIM.Add(t); // Yeni iletişim kaydını veritabanına ekler.
            db.SaveChanges();  // Değişiklikleri veritabanına kaydeder.
            return PartialView(); // İletişim formunu tekrar görüntüler.
        }
    }
}