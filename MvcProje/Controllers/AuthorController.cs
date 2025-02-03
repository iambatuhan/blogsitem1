using BusinessLayer;
using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager();
        AuthorManager am = new AuthorManager();
        Context c = new Context();
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = bm.GetBlogByID(id);
            return PartialView(authordetail);
        }

        
        public ActionResult AuthorList()
        {
           var authorlist= am.GetAll();
            return View(authorlist);
        }
        [AllowAnonymous]
        [HttpGet]
        public  ActionResult AddAuthor()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
          

              
            

            c.Authors.Add(p);
            c.SaveChanges();
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = am.FindAuthor(id);
            return View(author);
           
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            am.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult NewAddAuthor()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewAddAuthor(Author p)
        {
            am.AddAuthorBl(p);
            return RedirectToAction("AuthorList");
        }
        public ActionResult NewAddAuthor1()
        {
            return View();
        }
        public ActionResult AuthorDelet(int id)
        {
            am.DeleteBlog(id);
            return RedirectToAction("AuthorList");
        }
    }
}