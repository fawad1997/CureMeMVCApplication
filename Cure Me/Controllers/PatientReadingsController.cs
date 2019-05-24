using Cure_Me.Infrasturcture;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Controllers
{
    [CureMeAthorization]
    public class PatientReadingsController : Controller
    {
        static PatientReadingsIndex patientReadingIndex = new PatientReadingsIndex();
        // GET: PatientReadings
        public ActionResult Index()
        {
            populatePatientDropDown();
            return View(patientReadingIndex);
        }
        [HttpPost]
        public ActionResult Index(int patientID=0)
        {
            if (patientID > 0)
            {
                patientReadingIndex.patientID = patientID;
                patientReadingIndex.Patient = DataBase.Session.Query<PatientModel>().Where(x => x.ID == patientID).SingleOrDefault();
                patientReadingIndex.VitalSignReadings = DataBase.Session.Query<Patient_VitalSignReading_Model>().Where(x => x.PatientID == patientID).OrderByDescending(x=>x.Date_Time).ToList();
                ViewBag.selected = 1;

                populatePatientDropDown();

                return View(patientReadingIndex);
            }
            else
                return View(patientReadingIndex);
        }
        public void populatePatientDropDown()
        {
            var list = getPatientList().ToList();
            SelectList li = new SelectList(list, "id", "Name");
            patientReadingIndex.patientList = li;
        }
        public List<PatientModel> getPatientList()
        {
            List<PatientModel> s = new List<PatientModel>();
            IEnumerable<Patient_Doctor_Model> index = DataBase.Session.Query<Patient_Doctor_Model>().Where(x => (x.DoctorID == Convert.ToInt32(Session["DOCID"]) && x.isDischarged == 0)).ToList();
            for (int i = 0; i < index.Count(); i++)
            {
                PatientModel temp = DataBase.Session.Query<PatientModel>().Where(x => x.ID == index.ElementAt(i).PatientID && x.IsActive == 1 && x.IsDelete == 0).FirstOrDefault();
                if (temp != null)
                    s.Add(temp);
            }
            return s;
        }

    }
}