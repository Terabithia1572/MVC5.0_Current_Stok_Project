using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        dbMvcStokEntities1 db = new dbMvcStokEntities1();
        // GET: Urun
        public ActionResult Index(string p)
        {
            // var urunler = db.tbl_Urunler.Where(x => x.durum == true).ToList();
            //   var urunler = from x in db.tbl_Urunler select x; //tbl urunler içersinden çekicez bana bunlar içinden select x i çek
            var urunler = db.tbl_Urunler.Where( x=> x.durum == true);
            //Eğer ki benim gönderdiğim parametre değeri boş veya null değilse o zaman
            //urunler = urunler.Where(x => x.ad.Contains(p) && x.durum == true); ürünleri ad'a göre çek benim gönderdiğim parametrenin değerine göre çek dedik
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.ad.Contains(p) && x.durum == true);
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            // Bi tane Liste Öğresi oluşturduk amacımız ne ürünün kategorisini bu listeden çekmek
            //ktg adında bir değişken oluşturduk buraya bi tane linQ sorgusu göndericem yani from x in db.tbl_Kategori.ToList()
            //ile Kategori.ToList() ile kategorinin listesine ulaştım bitti mi hayır bitmedi
            //sonra diyicem ki select new SelecListItem şimdi yeni, bi tane seçim liste öğesi oluşturdum
            //bununda 2 tane parametresi oluyor C#'da kullandığımız combobox gibi 
            //yani C#'daki gibi Valumember ve Displaymember 2 parametre alıyor
            //Text kısmı Dropdownlist veya combobox'ta görünecek Değerimiz olacak(Displaymember)
            //Value ise arka planda çekeceğimiz değer olacak yani ID (ValueMember)
            List<SelectListItem> ktg = (from x in db.tbl_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,//buda kullanıcıya görünecek değer
                                            Value = x.id.ToString() // arka planda çalışıcak değer
                                        }).ToList(); // bunu bana ToList olarak yazdır dedik
                                                     //ktg ismideki değişkenime bu değeri atadım
                                                     //
            ViewBag.drop = ktg; //ktg'yi ne yapmam lazım taşımam lazım
                                //Diğer sayfalara bişey taşırken ViewBag ile taşıyorduk
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(tbl_Urunler t)
        {
            var ktgr = db.tbl_Kategori.Where(x => x.id == t.tbl_Kategori.id).FirstOrDefault();// LinQ sorgusu yazdık burada Where ile başladık x=> x öyleki x id'si t'den gönderdiğim id'ye eşit olan değerin (FirstOrDefault()); ilk değeri al anlamında kullandık
            t.tbl_Kategori = ktgr;
            db.tbl_Urunler.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.tbl_Kategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()

                                         }).ToList();
            var ktgr = db.tbl_Urunler.Find(id);
            ViewBag.urunkategori = kat;
            return View("UrunGetir", ktgr);
        }

        public ActionResult UrunGuncelle(tbl_Urunler p)
        {
            var urun = db.tbl_Urunler.Find(p.id);
            urun.ad = p.ad;
            urun.marka = p.marka;
            urun.stok = p.stok;
            urun.alisFiyat = p.alisFiyat;
            urun.satisFiyat = p.satisFiyat;
            var ktg = db.tbl_Kategori.Where(x => x.id == p.tbl_Kategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(tbl_Urunler p1)
        {
            var urunBul = db.tbl_Urunler.Find(p1.id);
            urunBul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }

   
}