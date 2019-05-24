using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Areas.Admin.Models
{
    public class AdminModel
    {
        public virtual int Admin_Id { get; set; }
        public virtual String Name { get; set; }
        public virtual String Email { get; set; }
        public virtual String Password { get; set; }
        public virtual int isDeleted { get; set; }
        public virtual String Gender { get; set; }
        public virtual int Age { get; set; }
        public virtual String About { get; set; }
        public virtual String Phone { get; set; }
        public virtual String Image_name { get; set; }
        public virtual String Image_url { get; set; }

    }
    public class Admin_Map : ClassMapping<AdminModel>
    {
        public Admin_Map()
        {
            Table("Admin");
            Id(x => x.Admin_Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("admin_id");
            });
            Property(x => x.Name,y=>y.NotNullable(true));
            Property(x => x.Email, y => y.NotNullable(true));
            Property(x => x.Password, y => y.NotNullable(true));
            Property(x => x.isDeleted, y => y.NotNullable(true));
            Property(x => x.Gender, y => y.NotNullable(true));
            Property(x => x.Age, y => y.NotNullable(true));
            Property(x => x.About);
            Property(x => x.Phone);
            Property(x => x.Image_name);
            Property(x => x.Image_url);
        }
    }
}