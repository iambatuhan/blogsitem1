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
    public class OnarımController : Controller
    {
        // GET: OnarımBildirim
        OnarımManager om = new OnarımManager();
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminBlogList()
        {
            var BlogList = om.GetAll();
            return View(BlogList);
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            List<SelectListItem> values2 = (from x in c.ArızaBildirmes
                                            where x.AtanmaDurum == false
                                            select new SelectListItem
                                            {
                                                Text = x.Acıklama,
                                                Value = x.ArızaKayıtID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
          
            List<SelectListItem> values4 = (from x in c.Blogs.ToList() select new SelectListItem { Text = x.MakineKodu, Value = x.MakineKodu.ToString() }).ToList();
            ViewBag.values4 = values4;
            List<SelectListItem> values5 = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values5 = values5;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Onarım b)
        {
            Context c = new Context();
            var arizaKayit = c.ArızaBildirmes.FirstOrDefault(x => x.ArızaKayıtID == b.ArızaKayıtID);
            if (arizaKayit != null)
            {
                arizaKayit.AtanmaDurum = true;
            }
            // Değişiklikleri veritabanına kaydediyoruz
            c.SaveChanges();
            b.AtanmaSaati = DateTime.Now;
            b.BaşlamaSaati = DateTime.Now;
            b.BitisSaati = DateTime.Now;
            b.AraVermeZamanı = DateTime.Now;
            om.BlogAddL(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult Listeleme()
        {
            var BlogList = om.GetAll();
            return View(BlogList);
        }
        public ActionResult DeleteBlog(int id)
        {
            om.DeleteAdmin(id);
            return RedirectToAction("AdminBlogList","Onarım");
        }
        public ActionResult AdminBlogList1()
        {
            var BlogList = om.GetAll().Where(o => o.Başlama == false && o.BitisDurum == false).ToList(); ;
            return View(BlogList);
        }
        public ActionResult AdminBlogList2()
        {
            var BlogList = om.GetAll().Where(o => o.BitisDurum == true).ToList();
            return View(BlogList);
        }
        public ActionResult AdminBlogList3()
        {
            var BlogList = om.GetAll().Where(o => o.Başlama == true && o.BitisDurum == false).ToList();
            return View(BlogList);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Onarım onarım = om.Update(id);
            Context c = new Context();
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            List<SelectListItem> values2 = (from x in c.ArızaBildirmes
                                            where x.AtanmaDurum == false
                                            select new SelectListItem
                                            {
                                                Text = x.Acıklama,
                                                Value = x.ArızaKayıtID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
       
            List<SelectListItem> values4 = (from x in c.Blogs.ToList() select new SelectListItem { Text = x.MakineKodu, Value = x.MakineKodu.ToString() }).ToList();
            ViewBag.values4 = values4;
            return View(onarım);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Onarım p)
        {
            p.AtanmaSaati = DateTime.Now;
            p.BaşlamaSaati = DateTime.Now;
            p.BitisSaati = DateTime.Now;
            p.Durum = true;
            om.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog1(int id)
        {
            Onarım onarım = om.Update1(id);
            Context c = new Context();
            return View(onarım);
        }
        [HttpPost]
        public ActionResult UpdateBlog1(Onarım p)
        {
            if (ModelState.IsValid)
            {
                om.UpdateBlog1(p);
                return Json(new { success = true }); // Başarılı yanıt
            }
            return Json(new { success = false, message = "Veri geçersiz!" }); // Hata durumu
        }
        [HttpGet]
        public ActionResult UpdateBlog2(int id)
        {
            Onarım onarım = om.Update2(id);
            return View(onarım);
        }
        [HttpPost]
        public ActionResult UpdateBlog2(Onarım p)
        {
            if (ModelState.IsValid) // Model geçerli mi kontrol et
            {
                om.UpdateBlog2(p); // Güncelleme işlemi
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public ActionResult UpdateBlog3(int id)
        {
            Onarım onarım = om.Update3(id);
            return View(onarım);
        }
        [HttpPost]
        public ActionResult UpdateBlog3(Onarım p)
        {
            if (ModelState.IsValid) // Model geçerli mi kontrol et
            {
                om.UpdateBlog3(p); // Güncelleme işlemi
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
