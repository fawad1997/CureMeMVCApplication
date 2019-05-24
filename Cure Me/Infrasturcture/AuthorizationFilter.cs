using Cure_Me.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Infrasturcture
{
    public class CureMeAthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["DOCID"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Login"); 
            }
        }
     
    }
       
}