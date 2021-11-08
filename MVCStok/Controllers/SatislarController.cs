using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar

        dbMvcStokEntities1 db = new dbMvcStokEntities1();
        public ActionResult Index()
        {
            var satislar = db.tbl_Satislar.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {

            // Bi tane Liste Öğresi oluşturduk amacımız ne ürünün kategorisini bu listeden çekmek
            //ktg adında bir değişken oluşturduk buraya bi tane linQ sorgusu göndericem yani from x in db.tbl_Kategori.ToList()
            //ile Kategori.ToList() ile kategorinin listesine ulaştım bitti mi hayır bitmedi
            //sonra diyicem ki select new SelecListItem şimdi yeni, bi tane seçim liste öğesi oluşturdum
            //bununda 2 tane parametresi oluyor C#'da kullandığımız combobox gibi 
            //yani C#'daki gibi Valumember ve Displaymember 2 parametre alıyor
            //Text kısmı Dropdownlist veya combobox'ta görünecek Değerimiz olacak(Displaymember)
            //Value ise arka planda çekeceğimiz değer olacak yani ID (ValueMember)
            List<SelectListItem> urun = (from x in db.tbl_Urunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,//buda kullanıcıya görünecek değer
                                            Value = x.id.ToString() // arka planda çalışıcak değer
                                        }).ToList(); // bunu bana ToList olarak yazdır dedik
                                                     //ktg ismideki değişkenime bu değeri atadım
                                                     //
            ViewBag.drop1 = urun; //ktg'yi ne yapmam lazım taşımam lazım
                                  //Diğer sayfalara bişey taşırken ViewBag ile taşıyorduk

            //PERSONELLER
            List<SelectListItem> per = (from x in db.tbl_Personeller.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad+" "+x.soyad,//buda kullanıcıya görünecek değer
                                             Value = x.id.ToString() // arka planda çalışıcak değer
                                         }).ToList(); // bunu bana ToList olarak yazdır dedik
                                                      //ktg ismideki değişkenime bu değeri atadım
                                                      //
            ViewBag.drop2 = per; //ktg'yi ne yapmam lazım taşımam lazım
                                 //Diğer sayfalara bişey taşırken ViewBag ile taşıyorduk

            // MÜŞTERİLER
            List<SelectListItem> must = (from x in db.tbl_Musteriler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad+" "+x.soyad,//buda kullanıcıya görünecek değer
                                             Value = x.id.ToString() // arka planda çalışıcak değer
                                         }).ToList(); // bunu bana ToList olarak yazdır dedik
                                                      //ktg ismideki değişkenime bu değeri atadım
                                                      //
            ViewBag.drop3 = must; //ktg'yi ne yapmam lazım taşımam lazım
                                 //Diğer sayfalara bişey taşırken ViewBag ile taşıyorduk


            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tbl_Satislar p)
        {
            var urun = db.tbl_Urunler.Where(x => x.id == p.tbl_Urunler.id).FirstOrDefault();// LinQ sorgusu yazdık burada Where ile başladık x=> x öyleki x id'si t'den gönderdiğim id'ye eşit olan değerin (FirstOrDefault()); ilk değeri al anlamında kullandık
            var musteri = db.tbl_Musteriler.Where(x => x.id == p.tbl_Musteriler.id).FirstOrDefault();// LinQ sorgusu yazdık burada Where ile başladık x=> x öyleki x id'si t'den gönderdiğim id'ye eşit olan değerin (FirstOrDefault()); ilk değeri al anlamında kullandık
            var personel = db.tbl_Personeller.Where(x => x.id == p.tbl_Personeller.id).FirstOrDefault();// LinQ sorgusu yazdık burada Where ile başladık x=> x öyleki x id'si t'den gönderdiğim id'ye eşit olan değerin (FirstOrDefault()); ilk değeri al anlamında kullandık
            p.tbl_Urunler = urun;
            p.tbl_Musteriler = musteri;
            p.tbl_Personeller = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_Satislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}