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
    public class PatientScheduleController : Controller
    {
        static ScheduleIndex scheduleIndex = new ScheduleIndex();
        // GET: PatientSchedule
        public ActionResult Index()
        {
            //ScheduleIndex PatientList = new ScheduleIndex();
            var list = getPatientList().ToList();
            SelectList li = new SelectList(list, "id", "Name");
            scheduleIndex.patientList = li;
            return View(scheduleIndex);
        }
        [HttpPost]
        public ActionResult Index(ScheduleIndex m)
        {
            if (m.perDay > 0)
            {
                Patient_Doctor_Model patient_doctor_reg = new Patient_Doctor_Model()
                {
                    ID = DataBase.Session.Load<Patient_Doctor_Model>(m.patientID).ID,
                    DoctorID = Convert.ToInt32(Session["DOCID"]),
                    PatientID = m.patientID,
                    isDischarged = 0,
                    readingPerDay = m.perDay
                };
                DataBase.Session.Update(patient_doctor_reg);
                ViewBag.success = 1;
            }
            if (m.patientID > 0)
            {
                scheduleIndex.patientID = m.patientID;
                scheduleIndex.Patient = DataBase.Session.Query<PatientModel>().Where(x => x.ID == m.patientID).SingleOrDefault();
                scheduleIndex.perDay = DataBase.Session.Query<Patient_Doctor_Model>().Where(x => (x.PatientID == m.patientID && x.DoctorID == Convert.ToInt32(Session["DOCID"]))).SingleOrDefault().readingPerDay;
                ViewBag.selected = 1;
                return View(scheduleIndex);// RedirectToAction("ViewSchedule",new { pId = m.patientID });
            }
            else
                return View(scheduleIndex);
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