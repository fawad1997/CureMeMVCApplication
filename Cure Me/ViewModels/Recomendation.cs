using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.ViewModels
{
    public class RecomendationIndex
    {
        public SelectList patientList { get; set; }
        public String recomendationMessage { get; set; }
        public int recomendToID { get; set; }
    }
}