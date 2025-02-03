using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcProje.Controllers
{   
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Log
        [HttpGet]
        public ActionResult PersonelLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelLogin(Author p,Admin z)
        {
            Context c = new Context();
            var userinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password==p.Password);
            var admininfo = c.Admins.FirstOrDefault(x => x.UserName == z.UserName && x.Password == z.Password);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Mail, false);
                Session["Mail"] = userinfo.Mail.ToString();
                return RedirectToAction("BlogList","User");
            }
            else {
                return RedirectToAction("PersonelLogin", "Login");            }
            }

        [HttpGet]
        public ActionResult Ndghqd ()
            {
                return View();
            }
        [HttpPost]
        public ActionResult Ndghqd(Admin p)
        {
            Context c = new Context();
            var admininfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["UserName"] = admininfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "AnaSayfa");
            }
            else
            {
                return RedirectToAction("Ndghqd", "Login");

            }
        }
        public PartialViewResult Button()
        {
            return PartialView();
        }
    }
}