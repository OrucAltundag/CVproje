using CV_Proje.Models.Entity;
using CV_Proje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;

namespace CV_Proje.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim 
        // DeneyimRepository sınıfından bir nesne oluşturuluyor. Bu, deneyimlerle ilgili veritabanı işlemlerini gerçekleştirir.
        DeneyimRepository repo = new DeneyimRepository(); 

        public ActionResult Index()   // Varsayılan sayfa (Index) açıldığında çağrılan action.
        {
            var degerler = repo.List(); // Veritabanındaki tüm deneyimleri listelemek için repository'nin List() metodu çağrılıyor.
            return View(degerler);    // Elde edilen deneyim listesi View'e gönderiliyor.
        }
        [HttpGet] // Deneyim ekleme formunu görüntülemek için kullanılan GET metodu.
        public ActionResult DeneyimEkle()
        {
            return View();   // Kullanıcıya form döndürülür.
        }
        [HttpPost]  // Deneyim ekleme işlemini gerçekleştiren POST metodu.
        public ActionResult DeneyimEkle(TBL_DENEYIMLERIM p)
        {
            repo.TAdd(p);  // Formdan gelen deneyim bilgileri repository'nin TAdd metodu ile veritabanına ekleniyor.
            return RedirectToAction("Index"); // İşlem tamamlandıktan sonra kullanıcı Index sayfasına yönlendiriliyor.
        }
        public ActionResult DeneyimSil(int id)  // Belirli bir deneyimi silmek için kullanılan action.
        {
            TBL_DENEYIMLERIM t = repo.find(x => x.ID == id);   // Silinecek deneyim, repository'nin find metodu ile ID'ye göre bulunuyor.
            repo.Tdelete(t);  // Bulunan kayıt repository'nin Tdelete metodu ile siliniyor.
            return RedirectToAction("Index");   // İşlem tamamlandıktan sonra kullanıcı Index sayfasına yönlendiriliyor.
        }
        [HttpGet] // Belirli bir deneyimi düzenlemek için formu döndüren GET metodu.
        public ActionResult DeneyimGetir(int id)
        {
            TBL_DENEYIMLERIM t = repo.find(x => x.ID == id); // Düzenlenecek deneyim, ID'ye göre bulunup kullanıcıya View olarak gönderiliyor.
            return View(t);
        }
        [HttpPost]  // Deneyim düzenleme işlemini gerçekleştiren POST metodu.
        public ActionResult DeneyimGetir(TBL_DENEYIMLERIM p)
        {
            TBL_DENEYIMLERIM t = repo.find(x => x.ID == p.ID); // Düzenlenecek deneyim ID'ye göre bulunuyor.
              // Yeni bilgiler formdan gelen değerlere göre güncelleniyor.
            t.Baslik = p.Baslik;  // Deneyimin başlığı güncelleniyor.
            t.AltBaslik = p.AltBaslik;  // Alt başlık güncelleniyor.
            t.Tarih = p.Tarih;   // Tarih bilgisi güncelleniyor.
            t.Aciklama = p.Aciklama; // Açıklama güncelleniyor.
            repo.TUpdate(t);  // Güncellenmiş deneyim repository'nin TUpdate metodu ile veritabanına kaydediliyor.
            return RedirectToAction("Index"); // İşlem tamamlandıktan sonra kullanıcı Index sayfasına yönlendiriliyor.
        }

    }
}