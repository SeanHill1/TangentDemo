using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TangentSolutionsProject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string password { get; set; }
    }

    public class TokenModel
    {
        public string token { get; set; }
    }


}