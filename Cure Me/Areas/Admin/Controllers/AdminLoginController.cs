using Cure_Me.Areas.Admin.Models;
using Cure_Me.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginIndex model)
        {
          //  return Content(model.username + "  ,  " + model.password);
            if (!ModelState.IsValid)
                return View("Index");

            AdminModel admin = DataBase.Session.QueryOver<AdminModel>().Where(x => (x.Name == (model.username) || x.Email == (model.username)) && x.Password == (model.password) && x.isDeleted != 1).SingleOrDefault();
            if (admin != null)
            {
                Session["ADMINID"] = admin.Admin_Id; Session["ADMINNAME"] = admin.Name; Session["ADMINAVATAR"] = admin.Image_name;
                //return View("~/Views/Home/Index.cshtml");
                return RedirectToAction("AdminProfile", "Profiles");
            }
            else
            {
                //ViewBag.notValid = "true";
                ModelState.AddModelError("username", "User Name or Password is Not Valid");
                return View(model);
            }
        }
        //public ActionResult ResetPassword()
        //{
        //    return Content("This is get Req to Reset Password");
        //}
        public ActionResult Logout()
        {
            Session["ADMINID"] = null;
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}