using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class Patient_Doctor_Model
    {
        public virtual int ID { get; set; }
        public virtual int PatientID { get; set; }
        public virtual int DoctorID { get; set; }
        public virtual int isDischarged { get; set; }
        public virtual int readingPerDay { get; set; }
        public virtual String dischargeSlip { get; set; }
    }

    public class Patient_Doctor_Map : ClassMapping<Patient_Doctor_Model>
    {
        public Patient_Doctor_Map()
        {
            Table("patient_doctor");
            Id(x => x.ID, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("ID");
            });
            Property(x => x.PatientID, x =>
             {
                 x.Column("patient_id");
                 x.NotNullable(true);
             });
            Property(X => X.DoctorID,x=> {
                x.Column("doctor_id");
                x.NotNullable(true);
            });
            Property(x => x.isDischarged, x =>
             {
                 x.Column("isDischarge");
                 x.NotNullable(true);
            });
            Property(x => x.readingPerDay, x =>
            {
                x.Column("rPerDay");
                x.NotNullable(true);
            });
            Property(x => x.dischargeSlip);
        }
    }
} 