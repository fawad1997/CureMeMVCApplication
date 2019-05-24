using Cure_Me.Infrasturcture;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TransactionFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
