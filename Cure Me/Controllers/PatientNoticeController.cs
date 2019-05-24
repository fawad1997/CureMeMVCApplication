using Cure_Me.Infrasturcture;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Controllers
{
    [CureMeAthorization]
    public class PatientNoticeController : Controller
    {
        // GET: PatientNotice
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PatientNotice post)
        {
            DataBase.Session.Save(new PatientNoticeModel
            {
                DocID = Convert.ToInt32(Session["DOCID"]),
                Title = post.Title,
                Description=post.Desc,
                DateTime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ExpiryDate=post.ExpDate
            });
            ViewBag.successMsg = "Notice Posted Sucessfully";
            return View();
        }
    }
}