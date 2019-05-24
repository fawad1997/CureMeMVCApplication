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
    public class AdminSearchController : Controller
    {
            // GET: PatientSearch
            public ActionResult Index()
            {
                return PartialView();
            }
            [HttpPost]
            public ActionResult Index(String name)
            {
                return RedirectToAction("DoctorPatientSearch", new { name = name });
            }
            public ActionResult DoctorPatientSearch(String name)
            {
                if (name != null)
                {
                AdminSearchDoctorPatientSearch model = new AdminSearchDoctorPatientSearch();
                model.DoctorList= DataBase.Session.QueryOver<DoctorModel>().Where(x => (x.Name == name || x.Email == name)).List();
                model.PatientList = DataBase.Session.QueryOver<PatientModel>().Where(x => (x.Name == name || x.Email == name || x.RegistrationNo == name)).List();
                return View(model);
            }
                return RedirectToAction("AdminProfile", "Profiles",new {area="Admin"});
            }
        }
}