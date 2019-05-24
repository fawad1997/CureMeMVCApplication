using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.ViewModels
{
    public class ScheduleIndex
    {
        public SelectList patientList { get; set; }
        public int patientID { get; set; }
        public PatientModel Patient { get; set; }
        public int perDay { get; set; }
    }
}