using Cure_Me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cure_Me.ViewModels
{
    public class DoctorNoticeBoardIndex
    {
        public IEnumerable<DoctorNoticeBoard> docNotice { get; set; }
    }
}