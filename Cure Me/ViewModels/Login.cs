using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cure_Me.ViewModels
{
    public class LoginIndex
    {
        public String username { get; set; }
        public String password { get; set; }
        public String email { get; set; }
    }
}