using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProHub.Core.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public int EstablishmentId { get; set; }

        [Remote("CheckUser", "Account", HttpMethod = "POST", ErrorMessage = "Err_EmailNotUnique")]
        [EmailAddress(ErrorMessage = "Err_EmailNotValid")]
        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "Email", Prompt = "Email")]
        public string Email { get; set; }

        [RegularExpression(@"(^[\S]*(?=.*[\d])(?=.*[\W_])[\S]{8,15}$)", ErrorMessage = "Err_PasswordNotValid")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "ConfirmPassword", Prompt = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Err_PasswordConfirmationMatch")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "Name", Prompt = "Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "PhoneNumber", Prompt = "9665xxxxxxxx")]
        [RegularExpression(@"^(9665)([0-9]{8})$", ErrorMessage = "Err_MobileNotValid")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
