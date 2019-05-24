using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class Patient_Disease_Model
    {
        public virtual int ID { get; set; }
        public virtual int PatientID { get; set; }
        public virtual int DiseaseID { get; set; }

        //public virtual IList<PatientModel> Patients { get; set; }
        // public virtual IList<DiseaseModel> Diseases { get; set; }    
    }
    public class Patient_Disease_Map : ClassMapping<Patient_Disease_Model>
    {
       public Patient_Disease_Map()
        {
            Table("patient_disease");
            Id(x => x.ID, x =>
              {
                  x.Generator(Generators.Identity);
                  x.Column("patient_disease_id");
                 
              });
            Property(x => x.PatientID, x =>
            {
                x.Column("patient_id");
                x.NotNullable(true);
            });
            Property(x => x.DiseaseID, x =>
            {
                x.Column("disease_id");
                x.NotNullable(true);
            });
           // Bag(x => x.Patients, map => map.Key(k => k.Column("patient_id")), rel => rel.OneToMany());
            //Bag(x => x.Diseases, map => map.Key(k => k.Column("disease_id")), rel => rel.OneToMany());

        }

    }
}