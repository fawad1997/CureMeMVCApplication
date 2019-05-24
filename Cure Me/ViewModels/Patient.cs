using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cure_Me.ViewModels
{
    public class PatientIndex
    {
        public String PatientID { get; set; }
        [Required]
        public String PatientName { get; set; }
        public bool sleepApnea { get; set; }
        public bool hypertension { get; set; }
        public bool sepsis { get; set; }

    }
    public class PatientList
    {
       // public IEnumerable<PatientModel> patient { get; set; }
        public IEnumerable<PatientModel> Patient { get; set; }
    }
}