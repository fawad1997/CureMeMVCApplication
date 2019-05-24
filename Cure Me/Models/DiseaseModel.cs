using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class DiseaseModel
    {
        public virtual int DiseaseID { get; set; }
        public virtual String Name { get; set; }
        public virtual String Symptoms { get; set; }

        public virtual Patient_Disease_Model Patient_Disease { get; set; }
    }

    public class DiseaseMap : ClassMapping<DiseaseModel>
    {
        public DiseaseMap()
        {
            Table("disease");

            Id(x=>x.DiseaseID,x=> {
                x.Column("disease_id");
                x.Generator(Generators.Identity);
               });

            Property(x => x.Name, x =>
            {
                x.NotNullable(true);
                x.Column("name");
            });

            Property(x => x.Symptoms, x =>
            {
                x.NotNullable(true);
                x.Column("symptoms");
            });

            ManyToOne(x => x.Patient_Disease, x => x.Column("disease_id"));
        }
    }
}