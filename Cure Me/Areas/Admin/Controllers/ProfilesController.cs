using Cure_Me.Areas.Admin.Infrastructure;
using Cure_Me.Areas.Admin.Models;
using Cure_Me.Areas.Admin.ViewModels;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProfilesController : Controller
    {
        static String message = "";
        static String err = "";
        // GET: Admin/Profiles
        public ActionResult AdminProfile()
        {
            AdminIndex admin = new AdminIndex();
            admin.Admin = DataBase.Session.QueryOver<AdminModel>().Where(x => x.Admin_Id == Convert.ToInt32(Session["ADMINID"])).SingleOrDefault();
            ViewBag.msg = message;
            ViewBag.err = err;
            return View(admin);
        }
        public ActionResult DoctorProfile(int? DocID)
        {
            resetViewBagMessages();
            DoctorIndex model = new DoctorIndex();
            model.Doctor = DataBase.Session.QueryOver<DoctorModel>().Where(x => x.ID == DocID).SingleOrDefault();
            model.PatientList = getPatientList(DocID);
            return View(model);
        }
        public ActionResult PatientProfile(int? PatID)
        {
            resetViewBagMessages();
            PatientProfile profile = new PatientProfile();
            profile.Patient = DataBase.Session.QueryOver<PatientModel>().Where(x => x.ID == PatID).SingleOrDefault();
            profile.DiseaseList = DataBase.Session.QueryOver<Patient_Disease_Model>().Where(x => x.PatientID == PatID).List();
            profile.disease = getDiseaseList(profile);
            profile.Sepsis = profile.disease.Contains(1) ? true : false;
            profile.SleepApnea = profile.disease.Contains(2) ? true : false;
            profile.HyperTension = profile.disease.Contains(3) ? true : false;
            return View(profile);
        }
        public List<int> getDiseaseList(PatientProfile m)
        {
            resetViewBagMessages();
            List<int> l = new List<int>();
            foreach (var disease in m.DiseaseList)
            {
                l.Add(disease.DiseaseID);
            }
            return l;
        }
        public IEnumerable<PatientModel> getPatientList(int? DocID)
        {
            resetViewBagMessages();
            List<PatientModel> s = new List<PatientModel>();
            IEnumerable<Patient_Doctor_Model> index = DataBase.Session.Query<Patient_Doctor_Model>().Where(x => (x.DoctorID == DocID && x.isDischarged == 0)).ToList();
            for (int i = 0; i < index.Count(); i++)
            {
                PatientModel temp = DataBase.Session.Query<PatientModel>().Where(x => (x.ID == index.ElementAt(i).PatientID && x.IsDelete == 0)).FirstOrDefault();
                if (temp != null)
                    s.Add(temp);
            }
            return s;
        }

        [HttpPost]
        public ActionResult AdminEditDetails(AdminIndex post)
        {
            resetViewBagMessages();
            DataBase.Session.Update(post.Admin);
            message = "Personal Info Updated Sucessfully";
            return RedirectToAction("AdminProfile");
        }
        [HttpPost]
        public ActionResult AdminUpdateAvatar(AdminIndex post)
        {
            resetViewBagMessages();
            HttpPostedFileBase ImageUrl = Request.Files[0];
            if (ImageUrl != null && ImageUrl.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImageUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Avatar/"), fileName);
                ImageUrl.SaveAs(path);

                AdminModel admin = DataBase.Session.Load<AdminModel>(post.Admin.Admin_Id);
                //delete Previous file
                if (System.IO.File.Exists(admin.Image_url))
                {
                    System.IO.File.Delete(admin.Image_url);
                }
                //updating new file
                admin.Image_url = path;
                admin.Image_name = fileName;
                DataBase.Session.Update(admin);
                Session["ADMINAVATAR"] = fileName;
                if (System.IO.File.Exists(path))
                    message = "Avatar Sucessfully Updated";
            }
            else
            {
                err = "Error Occured while updating Avatar";
            }
            return RedirectToAction("AdminProfile");
        }

        [HttpPost]
        public ActionResult AdminUpdatePassword(AdminIndex post)
        {
            resetViewBagMessages();
            if (post.OldPassword != DataBase.Session.QueryOver<AdminModel>().Where(x => x.Admin_Id == post.Admin.Admin_Id).SingleOrDefault().Password)
            {
                err = "Old Password you enter is not correct";
            }
            else if (post.NewPassword == null || post.NewPassword != post.CnfrmPassword)
            {
                err = "Password do not match";
            }
            else
            {
                err = "";
                message = "Password Sucessfully Updated";
                AdminModel temp = DataBase.Session.Load<AdminModel>(post.Admin.Admin_Id);
                temp.Password = post.NewPassword;
                DataBase.Session.Update(temp);
            }
            return RedirectToAction("AdminProfile");
        }
        public static void resetViewBagMessages()
        {
            message = "";
            err = "";
        }
    }
    

}