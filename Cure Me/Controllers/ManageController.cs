using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Cure_Me.Models;
using Cure_Me.Infrasturcture;

namespace Cure_Me.Controllers
{
    public class ManageController: Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index","Main",new { Area = "Home" });
        }
    }
}