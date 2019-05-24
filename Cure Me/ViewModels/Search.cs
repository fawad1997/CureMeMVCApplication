using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.ViewModels
{
    public class PatientSearchSearchResult
    {
        public IEnumerable<PatientModel> SearchPatientList { get; set; }
    }
}