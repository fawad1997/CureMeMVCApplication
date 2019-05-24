using Cure_Me.Areas.Admin.Infrastructure;
using Cure_Me.Areas.ViewModels;
using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ManageDoctorController : Controller
    {
        // GET: Admin/ManageDoctor
        public ActionResult DoctorRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorRegistration(DoctorModel dm)
        {
            DataBase.Session.Save(dm);
            ViewBag.successMsg = "Doctor Sucessfully Register";
            return View();
        }
        public ActionResult DoctorList()
        {
            ManageDoctorList doctorList = new ManageDoctorList();
            doctorList.DoctorList = DataBase.Session.QueryOver<DoctorModel>().List();
            return View(doctorList);
        }
        
        public ActionResult EditDoctor(int DocID)
        {
            ManageDoctorEdit doc = new ManageDoctorEdit();
            doc.Doctor=DataBase.Session.Load<DoctorModel>(DocID);
            return View(doc);
        }
        [HttpPost]
        public ActionResult EditDoctor(ManageDoctorEdit post)
        {
            if (post != null)
            {
                DataBase.Session.Update(post.Doctor);
            }
            return RedirectToAction("DoctorList");
        }
    }
}