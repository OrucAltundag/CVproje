using CV_Proje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CV_Proje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_ADMIN p)
        {
            dbCVEntities db = new dbCVEntities();
            var bilgi = db.TBL_ADMIN.FirstOrDefault(x=>x.KullaniciAdi==p.KullaniciAdi && x.Sifre==p.Sifre);

            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi,false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index","Deneyim");
            }
            else
            { return RedirectToAction("Index", "Login"); }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }


    }
}