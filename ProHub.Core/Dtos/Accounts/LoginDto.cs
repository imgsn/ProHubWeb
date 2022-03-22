using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Core.Dtos.Accounts
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Err_EmailNotValid")]
        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "Email", Prompt = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Err_Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
