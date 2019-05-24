using Cure_Me.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cure_Me.Areas.Admin.ViewModels
{
    public class AdminIndex
    {
        public AdminModel Admin { get; set; }
        [DataType("Password"), Required]
        public String OldPassword { get; set; }
        [DataType("Password"), Required]
        public String NewPassword { get; set; }
        [DataType("Password"), Required]
        public String CnfrmPassword { get; set; }
        public String ImageUrl { get; set; }
    }
}