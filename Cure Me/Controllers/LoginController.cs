using Cure_Me.ViewModels;
using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cure_Me.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginIndex model)
        {
            if (!ModelState.IsValid)
                return View("Index");
            
            DoctorModel doc = DataBase.Session.QueryOver<DoctorModel>().Where(x => (x.Email == model.username) && x.isDeleted != 1 && x.Password==model.password).SingleOrDefault();
            
            //string pass = "test";
            //string hash = BCrypt.Net.BCrypt.HashPassword(pass, 13);
            //Boolean t = BCrypt.Net.BCrypt.Verify(pass, hash);

            if (doc != null/* && doc.CheckPassword(model.password)*/)
            {
                Session["DOCID"] = doc.ID; Session["DOCNAME"] = doc.Name;
                Session["DOCAVATAR"] = doc.Image_name;
                return RedirectToAction("List", "Patient");
            }
            else
            {
                ModelState.AddModelError("username", "User Name or Password is Not Valid");
                return View(model);
            }
        }
        //[HttpPost]
        //public ActionResult ResetPassword(String email)
        //{
        //    sendEmail("chhassan371391@gmail.com", "Cure Me", "Set Password");
        //    return Content("This is POST Req to Reset Password"+ email);
        //}

        public ActionResult Logout()
        {
            Session["DOCID"] = null;
            Session.Abandon();
            return RedirectToAction("Index");
        }
        //void sendEmail(string strTo, string strSubject, string strBody)
        //{
        //    MailMessage mail = new MailMessage();
        //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //    mail.From = new MailAddress("chhassan371391@gmail.com");
        //    mail.To.Add(strTo);

        //    mail.Subject = strSubject;
        //    mail.IsBodyHtml = true;
        //    mail.Body = strBody;

        //     SmtpServer.Port = 587;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential("chhassan371391@gmail.com", "chhassan1995");
        //    SmtpServer.EnableSsl = true;

        //    SmtpServer.Send(mail);
        //}
    }
}