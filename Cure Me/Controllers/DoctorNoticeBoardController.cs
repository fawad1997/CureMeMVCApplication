using Cure_Me.Infrasturcture;
using Cure_Me.Models;
using Cure_Me.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cure_Me.Controllers
{
    [CureMeAthorization]
    public class DoctorNoticeBoardController : Controller
    {
        // GET: DoctorNoticeBoard
        public ActionResult Index()
        {
            DoctorNoticeBoardIndex notices = new DoctorNoticeBoardIndex();
            notices.docNotice = DataBase.Session.QueryOver<DoctorNoticeBoard>().List();
            return View(notices);
        }
    }
}