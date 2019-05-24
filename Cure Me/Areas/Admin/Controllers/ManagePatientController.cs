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
    public class ManagePatientController : Controller
    {
        // GET: Admin/ManagePatient
        public ActionResult PatientList()
        {
            ManagePatientList managePatient = new ManagePatientList();
            managePatient.PatientList = DataBase.Session.QueryOver<PatientModel>().Where(x => x.IsActive == 1 && x.IsDelete == 0).List();
            managePatient.assocDoc = new List<DoctorModel>();
            foreach (var a in managePatient.PatientList)
            {
                managePatient.assocDoc.Add(DataBase.Session.QueryOver<DoctorModel>().Where(x => x.ID == (DataBase.Session.QueryOver<Patient_Doctor_Model>().Where(y => y.PatientID == a.ID).SingleOrDefault().DoctorID)).SingleOrDefault());
            }
            return View(managePatient);
        }

        public ActionResult EditPatient(int PatID)
        {
            ManagePatientEdit pat = new ManagePatientEdit();
            pat.Patient = DataBase.Session.Load<PatientModel>(PatID);
            return View(pat);
        }
        [HttpPost]
        public ActionResult EditPatient(ManagePatientEdit post)
        {
            if (post != null)
            {
                DataBase.Session.Update(post.Patient);
            }
            return RedirectToAction("PatientList");
        }

    }
}