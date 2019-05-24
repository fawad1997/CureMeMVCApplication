using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.Models
{
    public class DoctorModel
    {
        public virtual int ID { get; set; }
        public virtual String Name { get; set; }
        public virtual String Email { get; set; }
        public virtual String Password { get; set; }
        public virtual String Phone { get; set; }
        public virtual String Specialization { get; set; }
        public virtual String Experience { get; set; }
        public virtual int isDeleted { get; set; }
        public virtual int Age { get; set; }
        public virtual String Gender { get; set; }
        public virtual String Image_url { get; set; }
        public virtual String Image_name { get; set; }
        //Test Comment for Github

        //public virtual void SetPassword(string password)
        //{
        //    Password = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(Password,DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt());
        //}
        //public virtual bool CheckPassword(string password)
        //{
        //    return DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(password, Password);
        //}
        //public virtual bool ComparePassword(string typedPassword,string oldPasswordHash)
        //{
        //    return DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(typedPassword, oldPasswordHash);
        //}

    }

    public class DoctorMap: ClassMapping<DoctorModel>
    {
        public DoctorMap()
        {
            Table("doctor");
            Id(x => x.ID, x =>
               {
                   x.Column("doctor_id");
                   x.Generator(Generators.Identity);
               });
            Property(x => x.Name, x=>x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.Password, x => x.NotNullable(true));
            Property(x => x.Phone);
            Property(x => x.Specialization);
            Property(x => x.Experience);
            Property(x => x.isDeleted, x => x.NotNullable(true));
            Property(x => x.Age, x => x.NotNullable(true));
            Property(x => x.Gender, x => x.NotNullable(true));
            Property(x => x.Image_url);
            Property(x => x.Image_name);
        }
    }
}