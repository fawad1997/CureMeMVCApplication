using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Areas.Admin.ViewModels
{
    public class AdminSearchDoctorPatientSearch
    {
        public IEnumerable<DoctorModel> DoctorList { get; set; }
        public IEnumerable<PatientModel> PatientList { get; set; }
    }
}