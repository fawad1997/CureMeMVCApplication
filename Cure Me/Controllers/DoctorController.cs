using Cure_Me.Infrasturcture;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Controllers
{
    [CureMeAthorization]
    public class DoctorController : Controller
    {
        static String message = "";
        static String err = "";
        // GET: Doctor
        public ActionResult Index() //Profile
        {
            DoctorIndex model = new DoctorIndex();
            model.Doctor = DataBase.Session.QueryOver<DoctorModel>().Where(x => x.ID == Convert.ToInt32(Session["DOCID"])).SingleOrDefault();
            model.PatientList = getPatientList();
            ViewBag.msg = message;
            ViewBag.err = err;
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateInfo(DoctorIndex post)
        {
            resetViewBagMessages();
            DataBase.Session.Update(post.Doctor);
            message = "Personal Info Updated Sucessfully";
           
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdatePassword(DoctorIndex post)
        {
            resetViewBagMessages();
            if (post.OldPassword != DataBase.Session.QueryOver<DoctorModel>().Where(x => x.ID == post.Doctor.ID).SingleOrDefault().Password)
            {
                err = "Old Password you enter is not correct";
            }else if (post.NewPassword==null || post.NewPassword != post.CnfrmPassword)
            {
                err = "Password do not match";
            }
            else
            {
                message = "Password Sucessfully Updated";
                DoctorModel temp = DataBase.Session.Load<DoctorModel>(post.Doctor.ID);
                temp.Password = post.NewPassword;
                DataBase.Session.Update(temp);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateAvatar(DoctorIndex post)
        {
            resetViewBagMessages();
            HttpPostedFileBase ImageUrl = Request.Files[0];
            if (ImageUrl != null && ImageUrl.ContentLength > 0) { 
                    var fileName = Path.GetFileName(ImageUrl.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/avatar/"), fileName);
                    ImageUrl.SaveAs(path);

                DoctorModel doctor = DataBase.Session.Load<DoctorModel>(post.Doctor.ID);
                //delete Previous file
                if (System.IO.File.Exists(doctor.Image_url))
                {
                    System.IO.File.Delete(doctor.Image_url);
                }
                //updating new file
                doctor.Image_url = path;
                doctor.Image_name = fileName;
                DataBase.Session.Update(doctor);
                Session["DOCAVATAR"] = fileName;
                if (System.IO.File.Exists(path))
                    message = "Avatar Sucessfully Updated";
            }
            else
            {
                err= "Error Occured while updating Avatar";
            }
            return RedirectToAction("Index");
        }
        public ActionResult DischargedList()
        {
            DoctorDischargedList list = new DoctorDischargedList();
            list.PatientList = new List<PatientModel>();
            list.dischargedPaientList = DataBase.Session.Query<Patient_Doctor_Model>().Where(x => (x.DoctorID == Convert.ToInt32(Session["DOCID"]) && x.isDischarged == 1)).ToList();
            for (int i = 0; i < list.dischargedPaientList.Count(); i++)
            {
                PatientModel temp = DataBase.Session.Query<PatientModel>().Where(x => x.ID == list.dischargedPaientList.ElementAt(i).PatientID).FirstOrDefault();
                if (temp != null)
                    list.PatientList.Add(temp);
            }
            return View(list);
        }
        public ActionResult DischargePatient()
        {
            DoctorDischargePatient model = new DoctorDischargePatient();
            var list = getPatientList().ToList();
            SelectList li = new SelectList(list, "id", "Name");
            model.patientList = li;
            return View(model);
        }
        [HttpPost]
        public ActionResult DischargePatient(DoctorDischargePatient post)
        {
            if (post.patientID > 0)
            {
                Patient_Doctor_Model patient_doctor_reg = new Patient_Doctor_Model()
                {
                    ID = DataBase.Session.Load<Patient_Doctor_Model>(post.patientID).ID,
                    DoctorID = Convert.ToInt32(Session["DOCID"]),
                    PatientID = post.patientID,
                    isDischarged = 1,
                    dischargeSlip = post.dischargeSlip
                };
                DataBase.Session.Update(patient_doctor_reg);
                ViewBag.successMsg = "Patient Successfully Discharged";
            }
            else
            {
                ViewBag.successMsg = "PLease Select Patient";
            }
            var list = getPatientList().ToList();
            SelectList li = new SelectList(list, "id", "Name");
            post.patientList = li;
            return View(post);
        }
        public IEnumerable<PatientModel> getPatientList()
        {
            List<PatientModel> s = new List<PatientModel>();
            IEnumerable<Patient_Doctor_Model> index = DataBase.Session.Query<Patient_Doctor_Model>().Where(x => (x.DoctorID == Convert.ToInt32(Session["DOCID"]) && x.isDischarged == 0)).ToList();
            for (int i = 0; i < index.Count(); i++)
            {
                PatientModel temp = DataBase.Session.Query<PatientModel>().Where(x => (x.ID == index.ElementAt(i).PatientID && x.IsDelete == 0)).FirstOrDefault();
                if (temp != null)
                    s.Add(temp);
            }
            return s;
        }
        public static void resetViewBagMessages()
        {
            message = "";
            err = "";
        }
    }
}