using Cure_Me.Infrasturcture;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Controllers
{
    [CureMeAthorization]
    public class PatientSearchController : Controller
    {
        // GET: PatientSearch
        [ChildActionOnly]
        public ActionResult Index()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Index(String name)
        {
                return RedirectToAction("SearchResult", new { name = name });
        }
        public ActionResult SearchResult(String name)
        {
            if (name != null)
            {
                PatientSearchSearchResult result = new PatientSearchSearchResult();
                result.SearchPatientList = DataBase.Session.QueryOver<PatientModel>().Where(x => ( x.Name==name || x.Email==name || x.RegistrationNo== name)).List();
                return View(result);
            }
            return RedirectToAction("Index", "Doctor");
        }
    }
}