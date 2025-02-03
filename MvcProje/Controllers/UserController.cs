using BusinessLayer;
using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcProje.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserProfilManager UserProfil = new UserProfilManager();
        BlogManager bm = new BlogManager();
        Context c = new Context();
        AuthorManager am = new AuthorManager();
        OnarımManager om = new OnarımManager();
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            var mail = (string)Session["Mail"];
            var profilvalues = UserProfil.GetAuthorByMail(mail);
            return PartialView(profilvalues);
        }
        public ActionResult UpdateUserEdit(Author p)
        {

            UserProfil.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminBlogList1()
        {
            var BlogList = om.GetAll();
            return View(BlogList);
        }

        public ActionResult BlogList(String p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = UserProfil.GetBlogByAuthor(id);
            return View(blogs);
        }

        public ActionResult BlogList1(String p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = UserProfil.GetBlogByAuthor(id);
            return View(blogs);
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
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            b.BlogDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            Context c = new Context();
            string dosyaadı = Path.GetFileName(Request.Files[0].FileName);
            string uzantı = Path.GetExtension(Request.Files[0].FileName);
            string yol = "~/Image/" + dosyaadı + uzantı;
            Request.Files[0].SaveAs(Server.MapPath(yol));
            b.BlogImage = "/Image/" + dosyaadı + uzantı;
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("BlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("BlogList");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
                c.Authors.Add(p);
                c.SaveChanges();
                return RedirectToAction("AuthorLogin", "Login");
        }
        public ActionResult Listeleme(String p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = UserProfil.GetBlogByAuthor(id);
            return View(blogs);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("PersonelLogin", "Login");
        }
    

    }
}
