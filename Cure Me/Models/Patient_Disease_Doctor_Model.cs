using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class Patient_Disease_Doctor_Model
    {
        public virtual int DoctorID { get; set; }
        public virtual int PatentDiseaseID { get; set; }
    }
    public class Patient_Disease_Doctor_Map: ClassMapping<Patient_Disease_Doctor_Model>
    {
        public Patient_Disease_Doctor_Map()
        {
        }
    }
}