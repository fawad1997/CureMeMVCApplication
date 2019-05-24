using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.ViewModels
{
    public class PatientGraphIndex
    {
        public PatientModel Patient { get; set; }
        public IEnumerable<Patient_VitalSignReading_Model> readings { get; set; }
        public IEnumerable<Patient_Disease_Model> diseases { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool hasSepsis { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool hasHyperTension { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool hasSleepApnea { get; set; }
        public int rPerDay { get; set; }
    }
    public class PatientGraphData
    {
        public IEnumerable<Patient_VitalSignReading_Model> readingList { get; set; }
    }

}
