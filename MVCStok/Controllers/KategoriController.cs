using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        // Modelin oluşturmuş olduğum isminden bir nesne türetmem lazım çünkü model içerisnde bulunan tablolara ulaşmak için bunun ,.,n
        dbMvcStokEntities1 db = new dbMvcStokEntities1();
        public ActionResult Index()
        {
            //şimdi biz burda bir listeleme yani index metodunu listeleme metoduna çevirmemiz lazım o yüzden 
            // using MVCStok.Models.Entity;  modelimizi tanımladık 
            var kategoriler = db.tbl_Kategori.ToList();
            // var değişken vermemizin nedeni tablo içerisinde bir sayı olabilir karakter olabilir tarih olabilir bunun için

            return View(kategoriler);
        }

        [HttpGet] // bu ne zaman çalışıcak HttpGet olduğu zaman bu çalışsın dedik
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost] // HTTP POST olduğu zaman aşağıdaki işlem çalışsın dedik

        public ActionResult YeniKategori(tbl_Kategori p) //tbl_Kategori den bir p nesnesi oluşturduk
        {
            db.tbl_Kategori.Add(p); // db.tbl_Kategoriye Ekle neyi ekle p den gelen değeri tbl_kategori içersine ekle
            db.SaveChanges(); //Değişiklikleri Kaydet dedik
            return RedirectToAction("Index"); // beni bi aksiyona yönlendir hangi aksiyona ındex aksiyonuna
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = db.tbl_Kategori.Find(id);
            db.tbl_Kategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tbl_Kategori.Find(id);
            return View("KategoriGetir",ktgr);
        }

        public ActionResult KategoriGuncelle(tbl_Kategori k)
        {
            var ktg = db.tbl_Kategori.Find(k.id);
            ktg.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}