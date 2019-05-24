using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Areas.Admin.ViewModels
{
    public class ManagePatientList
    {
        public IEnumerable<PatientModel> PatientList { get; set; }
        public List<DoctorModel> assocDoc { get; set; }
    }
    public class PatientProfile
    {
        public PatientModel Patient { get; set; }
        public IEnumerable<Patient_Disease_Model> DiseaseList { get; set; }
        public IEnumerable<int> disease { get; set; }
        public bool Sepsis { get; set; }
        public bool HyperTension { get; set; }
        public bool SleepApnea { get; set; }
    }
    public class ManagePatientEdit
    {
        public PatientModel Patient { get; set; }
    }
}