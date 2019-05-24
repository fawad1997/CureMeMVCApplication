using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class Patient_VitalSignReading_Model
    {
        public virtual int PatientID { get; set; }
        public virtual int ID { get; set; }
        public virtual String Date_Time { get; set; }
        public virtual String Location { get; set; }
        public virtual float Temperature { get; set; }
        public virtual float Pulse { get; set; }
        public virtual float BreathingRate { get; set; }
        public virtual float Spo2 { get; set; }
        public virtual float SystolicBP { get; set; }
        public virtual float DecreasingMap { get; set; }
        public virtual int isCritical { get; set; }
    }

    public class Patient_VitalSignReading_Map : ClassMapping<Patient_VitalSignReading_Model>
    {
        public Patient_VitalSignReading_Map()
        {
            Table("patient_vitalsigns_reading");
            Id(x => x.ID, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("reading_id");
            });
            Property(x => x.PatientID, x =>
               {
                   x.Column("patient_id");
                   x.NotNullable(true);
               });
            Property(x => x.Date_Time, x =>
             {
                 x.Column("date_time");
                 x.NotNullable(true);
             });
            Property(x => x.Location, x =>
            {
                x.Column("reading_location");
                x.NotNullable(true);
            });
            Property(x => x.Temperature);
            Property(x => x.Pulse);
            Property(x => x.BreathingRate, x => x.Column("breathing_rate"));
            Property(x => x.Spo2);
            Property(x => x.SystolicBP, x => x.Column("systolic_bp"));
            Property(x => x.DecreasingMap, x => x.Column("decreasing_map"));
            Property(x => x.isCritical, x => x.Column("isCritical"));
        }
    } 
}