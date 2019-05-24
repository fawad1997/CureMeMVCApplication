using Cure_Me.Areas.Admin.Models;
using Cure_Me.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System.Web;

namespace Cure_Me
{
    public static class DataBase
    {
        private const string SessionKey="CureMe.DataBase.SessionKey";
        public static ISessionFactory _sessionFactory;
        public static ISession Session { get { return (ISession) HttpContext.Current.Items[SessionKey]; } }

        public static void Configure()
        {
            var config = new Configuration();

            //Configure the connection string 
            config.Configure();
            
            //add our mappings
            var mapper = new ModelMapper();
            mapper.AddMapping<PatientMap>();
            mapper.AddMapping<DiseaseMap>();
            mapper.AddMapping<Patient_Disease_Map>();
            mapper.AddMapping<DoctorMap>();
            mapper.AddMapping<Patient_Doctor_Map>();
            mapper.AddMapping<Patient_VitalSignReading_Map>();
            mapper.AddMapping<Patient_Recomendation_Map>();
            mapper.AddMapping<Patient_Notice_Map>();
            mapper.AddMapping<Admin_Map>();
            mapper.AddMapping<Doctor_NoticeBoard_Map>();

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            //create session factory
                var data = config.Configure(
                      HttpContext.Current.Server.MapPath(
                         @"Models\Configuration\hibernate.cfg.xml"));
                _sessionFactory = data.BuildSessionFactory();
        }
        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey]= _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
                _sessionFactory.Close();
            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}