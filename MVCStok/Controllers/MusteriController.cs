using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        dbMvcStokEntities1 db = new dbMvcStokEntities1();

        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            // var musteriListe = db.tbl_Musteriler.ToList();
            var musteriListe = db.tbl_Musteriler.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 10); //Diyor ki başlangıçtaki sayfa numarası kaçtan başlasın sayfa değerinden başlasın 2.parametre ise sayfada kaç tane ürün göstersin 3 tane gözüksün dedim
            return View(musteriListe);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {

            return View();
        }

        [HttpPost]

        public ActionResult YeniMusteri(tbl_Musteriler p)
        {
            if(!ModelState.IsValid) /*Eğer Farklıysa Modelstate.Isvalid yani Geçerlemeden Doğrulamadan farklıysa doğru yapılmamışsa örneğin boş bırakılmaması bir yer boş bırakılmışsa bu rayı geri döndür aksi durumda alttaki işlemi yap*/
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.tbl_Musteriler.Add(p); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(tbl_Musteriler p)
        {
            var musteriBul = db.tbl_Musteriler.Find(p.id);
            musteriBul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tbl_Musteriler.Find(id);
           
            return View("MusteriGetir", mus);
        }

        public ActionResult MusteriGuncelle(tbl_Musteriler t)
        {
            var mus = db.tbl_Musteriler.Find(t.id);
            mus.ad = t.ad;
            mus.soyad = t.soyad;
            mus.sehir = t.sehir;
            mus.bakiye = t.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}