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
    public class OnarımBildirimController : Controller
    {
        // GET: OnarımBildirim
        ArızaBildirmeManager om = new ArızaBildirmeManager();
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
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(ArızaBildirme b)
        {
            b.dateTime = DateTime.Now;
            om.BlogAddL(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            om.DeleteAdmin(id);
            return RedirectToAction("AdminBlogList");
        }


    }
}