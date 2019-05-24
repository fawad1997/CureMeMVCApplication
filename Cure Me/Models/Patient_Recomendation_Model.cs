using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class Patient_Recomendation_Model
    {
        public virtual int PatientID { get; set; }
        public virtual int DoctorID { get; set; }
        public virtual string Recomendation { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Patient_Recomendation_Model;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.PatientID == other.PatientID &&
                this.DoctorID == other.DoctorID;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ PatientID.GetHashCode();
                hash = (hash * 31) ^ DoctorID.GetHashCode();

                return hash;
            }
        }
    }
    public class Patient_Recomendation_Map : ClassMapping<Patient_Recomendation_Model>
    {

        public Patient_Recomendation_Map()
        {
            Table("patient_Recomendation");
            ComposedId(x =>
            {
                x.Property(y => y.PatientID, z =>
                 {
                     z.Column("patient_Id");
                     z.NotNullable(true);
                 });
                x.Property(y => y.DoctorID, z =>
                 {
                     z.Column("doctor_Id");
                     z.NotNullable(true);
                 });
            });
            Property(x => x.Recomendation, x =>
            {
                x.Column("recomendation");
                x.NotNullable(true);
            });
        }
    }
}