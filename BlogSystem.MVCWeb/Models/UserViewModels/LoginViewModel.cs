using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.MVCWeb.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="用户名")]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="密码")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
        [Display(Name ="记住我")]
        public bool RememberMe { get; set; }
    }
}