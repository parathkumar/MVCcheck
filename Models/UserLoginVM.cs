using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking.Models
{
    public class UserLoginVM
    {
        [Key]
        [RemoteAttribute("IsUserExist", "StudentLogin", ErrorMessage = "User Id Does not exist")]
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}