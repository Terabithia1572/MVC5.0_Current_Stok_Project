using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
using System.Web.Security;

namespace MVCStok.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap

        dbMvcStokEntities1 db = new dbMvcStokEntities1();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tbl_Admin t)
        {
            var bilgiler = db.tbl_Admin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if( bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index","Musteri");
            }
            else
            {
                return View();
            }
        }
    }
}