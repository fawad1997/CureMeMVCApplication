using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class PatientNoticeModel
    {
        public virtual int DocID { get; set; }
        public virtual String Title { get; set; }
        public virtual String Description { get; set; }
        public virtual String DateTime { get; set; }
        public virtual String ExpiryDate { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as PatientNoticeModel;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.DocID == other.DocID &&
                this.DateTime == other.DateTime;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ DocID.GetHashCode();
                hash = (hash * 31) ^ DateTime.GetHashCode();

                return hash;
            }
        }
    }

    public class Patient_Notice_Map: ClassMapping<PatientNoticeModel>
    {
       public Patient_Notice_Map()
        {
            Table("PatientNotice");
            ComposedId(x =>
            {
                x.Property(y => y.DocID, z =>
                {
                    z.Column("DocId");
                    z.NotNullable(true);
                });
                x.Property(y => y.DateTime, z =>
                {
                    z.Column("DateTime");
                    z.NotNullable(true);
                });
            });
            Property(x => x.Title,y=>y.NotNullable(true));
            Property(X => X.Description, y => y.NotNullable(true));
            Property(X => X.ExpiryDate, y => y.NotNullable(true));
        }

    }
}
