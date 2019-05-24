using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.ViewModels
{
    public class PatientDiseaseIndex
    {
        public SelectList patientList { get; set; }
        public int patientID { get; set; }
        public PatientModel Patient { get; set; }
        public IEnumerable<int> disease { get; set; }
        public IEnumerable<Patient_Disease_Model> patientDiseaseList { get; set; }
        //[System.ComponentModel.DefaultValue(false)]
        public bool Sepsis { get; set; }
        public bool HyperTension { get; set; }
        public bool SleepApnea { get; set; }
    }
}