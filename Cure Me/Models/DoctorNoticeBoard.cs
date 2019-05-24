using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class DoctorNoticeBoard
    {
        public virtual int id { get; set; }
        public virtual int admin_id { get; set; }
        public virtual String Title { get; set; }
        public virtual String Description { get; set; }
        public virtual String Date { get; set; }
        public virtual String ExpDate { get; set; }
    }
    public class Doctor_NoticeBoard_Map: ClassMapping<DoctorNoticeBoard>
    {
        public Doctor_NoticeBoard_Map()
        {
            Table("DoctorNotice");
            Id(x => x.id, y =>
            {
                y.Column("id");
                y.Generator(Generators.Identity);
            });
            Property(x => x.admin_id, x => x.NotNullable(true));
            Property(x => x.Title, x => x.NotNullable(true));
            Property(x => x.Description, x => x.NotNullable(true));
            Property(x => x.Date, x => x.NotNullable(true));
            Property(x => x.ExpDate, x => x.NotNullable(true));

        }
    }
}