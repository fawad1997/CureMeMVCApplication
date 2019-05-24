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
    public class PatientDiseaseController : Controller
    {
        static PatientDiseaseIndex diseaseIndex = new PatientDiseaseIndex();

        // GET: PatientDisease
        public ActionResult Index()
        {
            var list = getPatientList().ToList();
            SelectList li = new SelectList(list, "id", "Name");
            diseaseIndex.patientList = li;
            return View(diseaseIndex);
        }
        [HttpPost]
        public ActionResult Index(PatientDiseaseIndex m)
        {
            if (m.patientID > 0)
            {
                diseaseIndex.patientID = m.patientID;
                diseaseIndex.Patient = DataBase.Session.Query<PatientModel>().Where(x => x.ID == m.patientID).SingleOrDefault();
                diseaseIndex.patientDiseaseList = DataBase.Session.Query<Patient_Disease_Model>().Where(x => x.PatientID == m.patientID).ToList();
                diseaseIndex.disease = getDiseaseList(diseaseIndex);
                diseaseIndex.Sepsis = diseaseIndex.disease.Contains(1) ? true : false;
                diseaseIndex.SleepApnea = diseaseIndex.disease.Contains(2) ? true : false;
                diseaseIndex.HyperTension = diseaseIndex.disease.Contains(3) ? true : false;

                ViewBag.selected = 1;
                
                
                //if ((diseaseIndex.disease.Contains(1).Equals(m.Sepsis ? 1 : 0)))
                //{
                //    return Content("Speis is turned");
                //}
                return View(diseaseIndex);
            }
            else
                return View(diseaseIndex);
        }
        
        public List<int> getDiseaseList(PatientDiseaseIndex m)
        {
            List<int> l = new List<int>();
            foreach(var disease in m.patientDiseaseList)
            {
                l.Add(disease.DiseaseID);
            }
            return l;
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