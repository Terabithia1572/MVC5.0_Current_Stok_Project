using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        dbMvcStokEntities1 db = new dbMvcStokEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]

        public ActionResult YeniAdmin(tbl_Admin p)
        {
            db.tbl_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}