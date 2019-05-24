using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Areas.ViewModels
{
    public class ManageDoctorList
    {
        public IEnumerable<DoctorModel> DoctorList { get; set; }
    }
    public class ManageDoctorEdit
    {
        public DoctorModel Doctor { get; set; }
    }
}