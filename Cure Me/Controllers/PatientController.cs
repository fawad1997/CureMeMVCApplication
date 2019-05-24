using Cure_Me.Infrasturcture;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Controllers
{
    [CureMeAthorization]
    public class PatientController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Index(PatientIndex p)   //REGISTER PATIENT
        {
            if(!ModelState.IsValid)
                    return View("index");
            if (p.PatientName.Length >= 3)
                p.PatientID = p.PatientName.Substring(0, 3).ToUpper();
            else
                p.PatientID = p.PatientName.Substring(0, p.PatientName.Length).ToUpper();
            for(int i = 0; i < 6; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                p.PatientID += rand.Next(0, 9);
            }
            if (!DataBase.Session.Query<PatientModel>().Any(u => u.RegistrationNo == p.PatientID))
            {

                DataBase.Session.Save(new PatientModel
                {
                    RegistrationNo = p.PatientID,
                    Name = p.PatientName,
                    Password="123",
                    IsActive = 0,
                    IsDelete=0
                });
                PatientModel registeredPatient = DataBase.Session.Query<PatientModel>().First(i => i.RegistrationNo == p.PatientID);
                if (p.sepsis)
                {
                    DataBase.Session.Save(new Patient_Disease_Model
                    {
                        DiseaseID = 1,
                        PatientID = registeredPatient.ID

                    });
                }
                if (p.sleepApnea)
                {
                    DataBase.Session.Save(new Patient_Disease_Model
                    {
                        DiseaseID = 2,
                        PatientID = registeredPatient.ID
                    });
                }
                if (p.hypertension)
                {
                    DataBase.Session.Save(new Patient_Disease_Model
                    {
                        DiseaseID = 3,
                        PatientID = registeredPatient.ID
                    });
                }
                DataBase.Session.Save(new Patient_Doctor_Model
                {
                    PatientID = registeredPatient.ID,
                    DoctorID = Convert.ToInt32(Session["DOCID"]),
                    isDischarged = 0,
                    readingPerDay = 5
                });
                ViewBag.registerationMessage = p.PatientName + " Registered Sucessfully, ID is " + p.PatientID;
            }
            else
            {
                ViewBag.registerationMessage = "Some Error Occur while Registration; Please try Again!";
            }
            return View("index");

        }
        public ActionResult List()
        {
            PatientList list = new PatientList();
            list.Patient =getPatientList() ;
            return View(list);
        }
        public IEnumerable<PatientModel> getPatientList()
        {
            List<PatientModel> s = new List<PatientModel>();
            IEnumerable<Patient_Doctor_Model> index = DataBase.Session.Query<Patient_Doctor_Model>().Where(x => (x.DoctorID == Convert.ToInt32(Session["DOCID"]) && x.isDischarged==0)).ToList();
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