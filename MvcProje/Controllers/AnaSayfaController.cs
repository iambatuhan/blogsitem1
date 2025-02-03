    using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    public class AnaSayfaController : Controller
    {
        BlogManager bm = new BlogManager();
        Context c = new Context();
        // GET: Blog
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction( "PersonelLogin", "Login");
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
            var CategoryDesc = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryAcıklama).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            ViewBag.CategoryName = CategoryName;
            return View(BlogListCategory);
        }
        public ActionResult AdminBlogList()
        {
            // Son 3 blogu al
            var BlogList = bm.GetAll().OrderByDescending(x => x.BlogDate).Take(3).ToList();

            // Makine durumunu gruplama ve sayma
            var machineStatus = c.Blogs
                .GroupBy(m => m.Calısma_Durum)
                .Select(g => new
                {
                    Status = g.Key ? "Çalışıyor" : "Çalışmıyor",
                    Count = g.Count()
                })
                .ToList();

            var totalcount = bm.GetAll().Count();
            ViewBag.TotalCount = totalcount;

            var arıza = c.ArızaBildirmes.Count();
            ViewBag.arıza = arıza;

            ViewBag.MachineStatus = machineStatus;

            var isci = c.Authors.Count();
            ViewBag.isci = isci;

            var bitis = c.Onarıms.Where(g => g.BitisDurum == true).Count();
            ViewBag.bitis = bitis;

            // Yazarların onarım sayısını gruplama
            var authorsWithRepairCounts = c.Onarıms.GroupBy(o => new 
            { o.AuthorID,
              o.Author.AuthorName }) // Yazar adını da gruba dahil edin
             .Select(g => new
          {
         AuthorId = g.Key.AuthorID,
         AuthorName = g.Key.AuthorName, // Yazar adını alın
        RepairCount = g.Count()
           })
     .OrderByDescending(x => x.RepairCount)
     .ToList();
            // Yazarların onarım sayısını ViewBag'e JSON formatında ata
            ViewBag.AuthorsWithRepairCounts = Newtonsoft.Json.JsonConvert.SerializeObject(authorsWithRepairCounts);

            // Kategorilere göre arıza sayısını gruplama
            var arızaByCategory = c.ArızaBildirmes
                .GroupBy(a => a.CategoryID)
                .Select(g => new
                {
                    CategoryId = g.Key,
                    Count = g.Count()
                })
                .ToList();

            // Kategorileri almak için
            var categories = c.Categories.ToList();
            var categoryNames = categories.ToDictionary(c => c.CategoryID, c => c.CategoryName);

            // Kategorilere göre arıza sayısını eşleştir
            var arızaData = arızaByCategory.Select(a => new
            {
                CategoryName = categoryNames[a.CategoryId],
                Count = a.Count
            }).ToList();

            // Verileri ViewBag'e ata
            ViewBag.ArızaData = Newtonsoft.Json.JsonConvert.SerializeObject(arızaData);

            // En son 3 onarımı al
            var categoriesList = c.Onarıms.OrderByDescending(x => x.BitisSaati).Take(3).ToList();
            ViewBag.onarıms = categoriesList;

            var lastFaultReports = c.ArızaBildirmes.OrderByDescending(x => x.dateTime).Take(3).ToList();
            ViewBag.arızabildirim = lastFaultReports;

            // Blog listesini görünümle döndür
            return View(BlogList);
        }

        public ActionResult AdminBlogList1()
        {
            var BlogList = bm.GetAll();
            return View(BlogList);
        }
        public ActionResult KaynakList()
        {
            var BlogList = bm.GetBlogByCategory(2);
            return View(BlogList);
        }
        public ActionResult CncList()
        {
            var BlogList = bm.GetBlogByCategory(1);
            return View(BlogList);
        }
        public ActionResult Talaslıİmalat()
        {
            var BlogList = bm.GetBlogByCategory(5);
            return View(BlogList);
        }
        public ActionResult Montaj()
        {
            var BlogList = bm.GetBlogByCategory(4);
            return View(BlogList);
        }
        public ActionResult Pres()
        {
            var BlogList = bm.GetBlogByCategory(3);
            return View(BlogList);
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            b.BlogDate = DateTime.Now;
            bm.BlogAddL(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.Update(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            p.BlogDate = DateTime.Now;
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }
        //public ActionResult AuthorBlogList(int id)
        //{
        //    var blogs = bm.GetBlogByAuthorID(id);
        //    return View(blogs);
        //}
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Ndghqd", "Login");
        }
        [AllowAnonymous]
        public ActionResult Index5()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Grafik()
        {
            // Veritabanından verileri çekelim (kategorilere göre toplam satış)
            var machineStatus = c.Blogs
                .GroupBy(m => m.Calısma_Durum) // Çalışma durumu bool olduğu için doğru
                .Select(g => new
                {
                    Status = g.Key ? "Çalışıyor" : "Çalışmıyor",
                    Count = g.Count()
                })
                .ToList();
            // JSON formatına çevirip ViewBag'e atalım
            ViewBag.MachineStatus = machineStatus;
            return View();
        }
    }
}
