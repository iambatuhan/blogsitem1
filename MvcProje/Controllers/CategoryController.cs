using BusinessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        
        CategoryManager cm = new CategoryManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var categoryvalue = cm.GetAll();
            return View(categoryvalue);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetayCategory()
        {
            var categoryvalue = cm.GetAll();
            return PartialView(categoryvalue);
        }

        public ActionResult BlogDetail()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult Resim()
        {
            return PartialView();

        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            //CommentValidator bv = new CommentValidator();
            //ValidationResult result = bv.Validate(p);
            //if (result.IsValid)
            //{
            cm.BlogAddL(c);
                //}
                //else
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                //    }
                //}
                return View();
            }
        public ActionResult Index1()
        {
            var categoryvalue = cm.GetAll();
            return View(categoryvalue);
        }
        public ActionResult DeleteCategory(int id)
        {
            cm.DeleteBlog(id);
            return RedirectToAction("Index1");
        }
    }
    }
