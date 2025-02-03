using BusinessLayer;
using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
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
    public class AdminController : Controller
    {
        // GET: Default1
        Repository<Admin> repository = new Repository<Admin> { };
        AdminManager am = new AdminManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminList()
        {
            var adminlist = am.GetAll();
            return View(adminlist);

        }
        [HttpGet]
        public ActionResult AddNewAdmin()
        {
        
            return View();

        }
        [HttpPost]
        public ActionResult AddNewAdmin(Admin b)
        {

            
            am.BlogAddL(b);
            return RedirectToAction("AdminList");
        }
        public ActionResult DeleteAdmin(int id)
        {
            am.DeleteAdmin(id);
            return RedirectToAction("AdminBlogList","AnaSayfa");
        }
    }
    }