using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.ViewModels
{
    public class DoctorIndex
    {
        public DoctorModel Doctor { get; set; }
        public IEnumerable<PatientModel> PatientList { get; set; }
        [DataType("Password"),Required]
        public String OldPassword { get; set; }
        [DataType("Password"), Required]
        public String NewPassword { get; set; }
        [DataType("Password"), Required]
        public String CnfrmPassword { get; set; }
        public String ImageUrl { get; set; }

    }
    public class DoctorDischargePatient
    {
        public SelectList patientList { get; set; }
        public String dischargeSlip { get; set; }
        public int patientID { get; set; }
    }
    public class DoctorDischargedList
    {
        public IEnumerable<Patient_Doctor_Model> dischargedPaientList { get; set; }
        public List<PatientModel> PatientList { get; set; }
    }
}
