using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.ViewModels
{
    public class PatientReadingsIndex
    {
        public SelectList patientList { get; set; }
        public int patientID { get; set; }
        public PatientModel Patient { get; set; }
        public IEnumerable<Patient_VitalSignReading_Model> VitalSignReadings { get; set; }
    }
}