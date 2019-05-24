using Cure_Me.Areas.Admin.Infrastructure;
using Cure_Me.Areas.Admin.ViewModels;
using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class DocNoticeController : Controller
    {
        // GET: Admin/DoctorNoticeBoard
        public ActionResult AddNotice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNotice(DoctorNoticeAddNotice post)
        {
            DataBase.Session.Save(new DoctorNoticeBoard
            {
                Title = post.Title,
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ExpDate = post.ExpDate,
                Description = post.Desc,
                admin_id = Convert.ToInt32(Session["ADMINID"])
            });
            ViewBag.successMsg = "Notice Posted Sucessfully";
            return View();
        }
    }
}