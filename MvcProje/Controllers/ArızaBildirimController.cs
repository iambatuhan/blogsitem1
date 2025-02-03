using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ArızaBildirimController : Controller
    {
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

        public ActionResult DeleteBlog(int id)
        {
            om.DeleteAdmin(id);
            return RedirectToAction("AdminBlogList");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddNewBlog(ArızaBildirme b)
        {
            Context c = new Context();
            b.dateTime = DateTime.Now;

            // MakineAdı ile BlogID eşleşmesini yap
            var blog = c.Blogs.FirstOrDefault(x => x.BlogID.ToString() == b.MakineAdı);

            if (blog != null)
            {
                blog.Calısma_Durum = false;
                c.SaveChanges();
            }

            om.BlogAddL(b);

            string emailSubject = "Yeni Bir Arıza Girildi";
            string emailBody = $"Yeni Bir Arıza Girildi.\n" +
                               $"Bildirilen Arıza: {b.Acıklama}\n" +
                               $"Makine Adı: {b.MakineAdı}\n" +
                               $"Makine Kodu: {b.MakineKodu}\n" +
                               $"Tarih: {b.dateTime}\n";
            SendEmail(emailSubject, emailBody);

            return RedirectToAction("AddNewBlog", "ArızaBildirim");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            ArızaBildirme arızaBildirme = om.Update(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;

            return View(arızaBildirme);
        }

        [HttpPost]
        public ActionResult UpdateBlog(ArızaBildirme p)
        {
            p.dateTime = DateTime.Now;
            om.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult Listele()
        {
            var BlogList = om.GetAll();
            return View(BlogList);
        }

        // E-posta gönderme metodu
        private void SendEmail(string subject, string body)
        {
            var fromAddress = new MailAddress("batuhan.sen@omsmakina.com", "Batuhan Şen");
            var toAddress = new MailAddress("m.akif@omsmakina.com", "Batuhan Şen");
            const string fromPassword = "Batuhan.2024";
            const string smtpHost = "smtp.gmail.com";
            const int smtpPort = 587;

            var smtp = new SmtpClient
            {
                Host = smtpHost,
                Port = smtpPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        // Yeni JSON Result metodu: Belirli kategoriye ait makineleri döndürür
    }
}
