using Cure_Me.Infrasturcture;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Cure_Me.Controllers
{
    [CureMeAthorization]
    public class PatientGraphsController : Controller
    {
        // GET: PatientGraphs
        public ActionResult Index(int id)
        {
            PatientGraphIndex patient = new PatientGraphIndex();
            patient.Patient = DataBase.Session.QueryOver<PatientModel>().Where(x => x.ID == id).SingleOrDefault();
            patient.readings = DataBase.Session.QueryOver<Patient_VitalSignReading_Model>().Where(x => (x.Date_Time == DateTime.UtcNow.Date.ToString("yyyy-MM-dd") && x.PatientID == patient.Patient.ID)).List();
            patient.diseases = DataBase.Session.QueryOver<Patient_Disease_Model>().Where(x => x.PatientID == id).List();
            patient.rPerDay = DataBase.Session.QueryOver<Patient_Doctor_Model>().Where(x => x.PatientID == id && x.DoctorID == Convert.ToInt32(Session["DOCID"])).SingleOrDefault().readingPerDay;

            string filepath = "C:\\wamp64\\www\\AndroidFileUpload\\uploads\\IMG_"+patient.Patient.ID+".jpg";
            string destPath = "C:\\Users\\Ch-Hassan\\Documents\\visual studio 2015\\Projects\\Cure Me\\Cure Me\\Content\\images\\patientAvatar\\IMG_"+patient.Patient.ID+".jpg";
            setPatientImage(filepath, destPath);
            ViewBag.img = "IMG_" + patient.Patient.ID + ".jpg";
            return View(patient);
        }

        public void setPatientImage(string source, string dest)
        {
            if (!System.IO.File.Exists(dest))
            {
                if (System.IO.File.Exists(source))
                {
                    System.IO.File.Copy(source, dest);
                }

            }

        }
        [ChildActionOnly]
        public ActionResult TemperatureChart(int id)
        {
            return PartialView(getTemperatureReadings(id));
        }
        private PatientGraphData getTemperatureReadings(int id)
        {
            PatientGraphData reading = new PatientGraphData();
            reading.readingList = DataBase.Session.QueryOver<Patient_VitalSignReading_Model>().Where(x => (x.PatientID == id && x.Temperature > 0)).OrderBy(x => x.Date_Time).Asc.List();
            return reading;
        }

        [ChildActionOnly]
        public ActionResult PulseChart(int id)
        {
            return PartialView(getPulseReadings(id));
        }
        [ChildActionOnly]
        public ActionResult SepsisPulseChart(int id)
        {
            return PartialView(getPulseReadings(id));
        }
        private PatientGraphData getPulseReadings(int id)
        {
            PatientGraphData r = new PatientGraphData();
            r.readingList = DataBase.Session.QueryOver<Patient_VitalSignReading_Model>().Where(x => (x.PatientID == id && x.Pulse > 0)).OrderBy(x => x.Date_Time).Asc.List();
            return r;
        }

        [ChildActionOnly]
        public ActionResult BreathingRChart(int id)
        {
            return PartialView(getBreathingRReading(id));
        }
        private PatientGraphData getBreathingRReading(int id)
        {
            PatientGraphData r = new PatientGraphData();
            r.readingList = DataBase.Session.QueryOver<Patient_VitalSignReading_Model>().Where(x => (x.PatientID == id && x.BreathingRate > 0)).OrderBy(x => x.Date_Time).Asc.List();
            return r;
        }

        [ChildActionOnly]
        public ActionResult SysBPChart(int id)
        {
            return PartialView(getSysBP(id));
        }
        private PatientGraphData getSysBP(int id)
        {
            PatientGraphData r = new PatientGraphData();
            r.readingList = DataBase.Session.QueryOver<Patient_VitalSignReading_Model>().Where(x => (x.PatientID == id && x.SystolicBP > 0)).OrderBy(x => x.Date_Time).Asc.List();
            return r;
        }

        [ChildActionOnly]
        public ActionResult Spo2Chart(int id)
        {
            return PartialView(getSpo2(id));
        }
        private PatientGraphData getSpo2(int id)
        {
            PatientGraphData r = new PatientGraphData();
            r.readingList = DataBase.Session.QueryOver<Patient_VitalSignReading_Model>().Where(x => (x.PatientID == id && x.Spo2 > 0)).OrderBy(x => x.Date_Time).Asc.List();
            return r;
        }

        [ChildActionOnly]
        public ActionResult DecMapChart(int id)
        {
            return PartialView(getDecMap(id));
        }
        private PatientGraphData getDecMap(int id)
        {
            PatientGraphData r = new PatientGraphData();
            r.readingList = DataBase.Session.QueryOver<Patient_VitalSignReading_Model>().Where(x => (x.PatientID == id && x.DecreasingMap > 0)).OrderBy(x => x.Date_Time).Asc.List();
            return r;
        }


    }
}