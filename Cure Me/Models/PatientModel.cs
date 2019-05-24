using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class PatientModel
    {
        public virtual int ID { get; set; }
        public virtual String Name { get; set; }
        public virtual int Age { get; set; }
        public virtual String Email { get; set; }
        public virtual String Password { get; set; }
        public virtual String Phone { get; set; }
        public virtual String Gender { get; set; }
        public virtual String Address { get; set; }
        public virtual int IsActive { get; set; }
        public virtual String RegistrationNo { get; set; }
        public virtual int IsDelete { get; set; }


       // public virtual Patient_Disease_Model Patient_Disease { get; set; }

    }
    public class PatientMap : ClassMapping<PatientModel>
    {
        public PatientMap()
        {
            Table("patient");
            Id(x => x.ID, x => {
                x.Generator(Generators.Identity);
                x.Column("patient_id");
                });
            Property(x => x.Name);
            Property(x => x.Age);
            Property(x => x.Email);
            Property(x => x.Password);
            Property(x => x.Phone);
            Property(x => x.Address);
            Property(x => x.Gender);
            Property(x => x.IsActive, x => {
                x.NotNullable(true);
                x.Column("isActive");
                });
            Property(x => x.RegistrationNo, x =>
            {
                x.Column("registration_no");
                x.NotNullable(true);
            });
            Property(x => x.IsDelete, x =>
            {
                x.Column("isDelete");
                x.NotNullable(true);
            });
         // ManyToOne(x=>x.Patient_Disease,x=>x.Column("patient_id"));
        }
    }
}