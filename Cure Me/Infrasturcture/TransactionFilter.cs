using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Infrasturcture
{
    public class TransactionFilter : System.Web.Mvc.IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DataBase.Session.BeginTransaction();
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
                DataBase.Session.Transaction.Commit();
            else
                DataBase.Session.Transaction.Rollback();
        }

    }
}