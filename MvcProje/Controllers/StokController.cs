using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok
        StokManager sm = new StokManager();
        Repository<Stok> repoadmin = new Repository<Stok>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminBlogList()
        {
            var BlogList = sm.GetAll();
            return View(BlogList);
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
     
            List<SelectListItem> values2 = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Stok b)
        {
            b.son_güncelleme = DateTime.Now;
            sm.BlogAddL(b);
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult Listeleme()
        {
            var BlogList = sm.GetAll();
            return View(BlogList);
        }

        public ActionResult DeleteBlog(int id)
        {
            sm.DeleteAdmin(id);
            return RedirectToAction("AdminBlogList");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Stok onarım = sm.Update(id);
            Context c = new Context();
            List<SelectListItem> values1 = (from x in c.Blogs.ToList() select new SelectListItem { Text = x.MakineKodu, Value = x.MakineKodu.ToString() }).ToList();
            ViewBag.values1 = values1;
            List<SelectListItem> values2 = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View(onarım);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Stok p)
        {
            sm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList", "Stok");
        }

        [HttpPost]
        public JsonResult UpdateStok(int id, int miktar)
        {
            try
            {
                // Stok kaydını veritabanında bul
                var stok = repoadmin.Find(x => x.StokID == id);

                if (stok != null)
                {
                    // Stok miktarını artırma veya azaltma
                    stok.Miktar += miktar;

                    // Son güncelleme zamanını güncelle
                    stok.son_güncelleme = DateTime.Now;

                    // Veritabanında değişiklikleri kaydet
                    repoadmin.Update(stok);

                    // Kritik stok seviyesi kontrolü
                    if (stok.Miktar < 200)
                    {
                        return Json(new { success = true, message = "Stok başarıyla güncellendi, fakat stok seviyesi kritik seviyede." });
                    }

                    // Stok başarıyla güncellendi mesajı
                    return Json(new { success = true, message = "Stok başarıyla güncellendi." });
                }

                // Stok bulunamazsa hata mesajı
                return Json(new { success = false, message = "Stok bulunamadı." });
            }
            catch (Exception ex)
            {
                // Hata yakalama ve mesaj döndürme
                return Json(new { success = false, message = "Hata oluştu: " + ex.Message });
            }
        }

    }
}
