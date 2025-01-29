using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// `using` direktifleri, projede gerekli olan kütüphaneleri içeri aktarmaktadır. 
// `System.Web.Mvc` kütüphanesi, MVC yapısının temel bileşenlerini sağlar.

namespace CV_Proje.Controllers
{
    // Bu satır, kodun `CV_Proje.Controllers` isim alanı altında olduğunu belirtir.
    // Controllers klasöründe yer alır ve bu isim alanı altında tanımlanmıştır.

    public class HomeController : Controller
    {   
        // `HomeController` sınıfı, `Controller` sınıfından türemiştir.
        // Bu sınıf, web sayfası için çeşitli aksiyon metodlarını içerir.
        public ActionResult Index()
        {
            // `Index` metodu, web uygulamasının ana sayfasını temsil eder.
            // Bu metod çağrıldığında, `Index` görünümü (View) geri döndürülür.

            return View();
        }

        public ActionResult About()

        // `About` metodu, uygulama hakkında bilgi veren bir sayfayı temsil eder.
        // `ViewBag` kullanılarak mesaj içeriği taşınır ve görünümde kullanılabilir hale getirilir.
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            // `Contact` metodu, iletişim sayfasını temsil eder.
            // Kullanıcıya bir mesaj göstermek için `ViewBag` kullanılır.

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}