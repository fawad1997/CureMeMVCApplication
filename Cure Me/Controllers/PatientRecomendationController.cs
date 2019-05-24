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
    public class PatientRecomendationController : Controller
    {
        static RecomendationIndex recomendationIndex = new RecomendationIndex();
        // GET: PatientRecomendation
        public ActionResult Index()
        {
            var list = getPatientList().ToList();
            SelectList li = new SelectList(list, "id", "Name");
            recomendationIndex.patientList = li;
            return View(recomendationIndex);
        }
        [HttpPost]
        public ActionResult Index(RecomendationIndex post)
        {
            DataBase.Session.Save(new Patient_Recomendation_Model
            {
                PatientID = post.recomendToID,
                DoctorID = Convert.ToInt32(Session["DOCID"]),
                Recomendation = post.recomendationMessage
            });
            ViewBag.successMsg="Sent Sucessfully";
            return View(recomendationIndex);
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