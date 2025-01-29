using CV_Proje.Models.Entity;
using CV_Proje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Proje.Controllers
{
    // Eğitim işlemlerini yöneten bir controller tanımlanıyor.
    public class EgitimController : Controller
    {
        dbCVEntities db = new dbCVEntities();
        // Generic repository oluşturuluyor. Eğitimlerle ilgili işlemler için kullanılıyor.
        GenericRepository<TBL_EGITIMLERIM> repo = new GenericRepository<TBL_EGITIMLERIM>();
        // GET: Egitim
        public ActionResult Index()   // Eğitim bilgilerini listeleyen action.
        {
            var egitim = repo.List();  // Tüm eğitim bilgileri repository'nin List() metodu ile alınır.
            return View(egitim); // Alınan liste, View'e gönderilir.
        }
        [HttpGet]  // Eğitim ekleme formunu görüntülemek için kullanılan GET metodu.
        public ActionResult EgitimEkle()
        {
            return View(); // Kullanıcıya boş bir form döndürülür.
        }
        [HttpPost]  // Eğitim ekleme işlemini gerçekleştiren POST metodu.
        public ActionResult EgitimEkle(TBL_EGITIMLERIM p)
        {
            if (!ModelState.IsValid)  // Eğer model valid değilse, yani formdaki veriler kurallara uygun değilse.
            {
                return View("EgitimEkle");   // Kullanıcı tekrar aynı form sayfasına yönlendirilir.
            }
            repo.TAdd(p);  // Validasyon sağlanmışsa, eğitim bilgisi veritabanına kaydedilir.
            return RedirectToAction("Index"); // İşlem tamamlandıktan sonra Index sayfasına yönlendirme yapılır.
        }
        public ActionResult EgitimSil(int id)  // Belirli bir eğitim bilgisini silen action.
        {
            var egitim = repo.find(x => x.ID == id);   // Silinecek eğitim bilgisi ID'ye göre bulunur.
            repo.Tdelete(egitim);   // Bulunan kayıt repository'nin Tdelete metodu ile silinir.
            return RedirectToAction("Index");   // İşlem tamamlandıktan sonra Index sayfasına yönlendirme yapılır.
        }
        [HttpGet]  // Eğitim düzenleme formunu görüntülemek için kullanılan GET metodu.
        public ActionResult EgitimDuzenle(int id) 
        {
            var egitim = repo.find(x => x.ID == id);  // Düzenlenecek eğitim bilgisi ID'ye göre bulunur.
            return View(egitim);    // Bulunan eğitim bilgisi View'e gönderilir.
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TBL_EGITIMLERIM t)
        {
            if (!ModelState.IsValid)  // Eğer model valid değilse, yani formdaki veriler kurallara uygun değilse.
            {
                return View("EgitimDuzenle"); // Kullanıcı tekrar aynı form sayfasına yönlendirilir.
            }
            var egitim = repo.find(x => x.ID == t.ID); // Validasyon sağlanmışsa, düzenlenecek eğitim bilgisi ID'ye göre bulunur.
            egitim.Baslik=t.Baslik;
            egitim.AltBaslik1 = t.AltBaslik1;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.Tarih=t.Tarih;
            egitim.GNO=t.GNO;
            repo.TUpdate(egitim);  // Güncellenmiş eğitim bilgisi repository'nin TUpdate metodu ile veritabanına kaydedilir.
            return RedirectToAction("Index");
        }
    }
}
