﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Areas.Admin.Infrastructure
{
    public class AdminAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["ADMINID"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Admin/AdminLogin/Index");
            }
        }
    }
}