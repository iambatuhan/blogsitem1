using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("PersonelLogin", "Login");
        }
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string language)
        {
            HttpCookie cookie;
            cookie = new HttpCookie("MultiLanguageExample");
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            cookie.Value = language;
            Response.SetCookie(cookie);
            if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.LocalPath);
            return Redirect("/Home/Index");
        }

    }
}