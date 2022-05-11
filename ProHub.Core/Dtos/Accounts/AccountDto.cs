using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProHub.Core.Dtos.Establishments;

namespace ProHub.Core.Dtos.Accounts
{
    public class AccountDto
    {
        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "FullName", Prompt = "FullName")]

        public string FullName { get; set; }

        //[Required(ErrorMessage = "Err_Required")]
        //[Display(Name = "LastName", Prompt = "LastName")]
        //public string LastName { get; set; }


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
        [Required(ErrorMessage = "b")]
        [Display(Name = "ConfirmPassword", Prompt = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Err_PasswordConfirmationMatch")]
        public string ConfirmPassword { get; set; }




        [Required(ErrorMessage = "Err_Required")]
        [RegularExpression(@"^(9665)([0-9]{8})$", ErrorMessage = "Err_MobileNotValid")]

        [Display(Name = "MobileNumber", Prompt = "9665xxxxxxxx")]
        public string MobileNumber { get; set; }

        public int EstablishmentId { get; set; }

        //[Required(ErrorMessage = "Err_Required")]
        //[Display(Name = "WorkPhone", Prompt = "WorkPhone")]
        //public string WorkPhone { get; set; }

        //[Required(ErrorMessage = "Err_Required")]
        //[Display(Name = "ActivationKey", Prompt = "ActivationKey")]
        //public string ActivationKey { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "ActivationDate", Prompt = "ActivationDate")]
        public DateTime ActivationDate { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "ExpiryDate", Prompt = "ExpiryDate")]
        public DateTime? ExpiryDate { get; set; }


        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "IsActive", Prompt = "IsActive")]
        public bool IsActive { get; set; }

        //public DateTime? LastLocationDate { get; set; }
        //public string LastLocationAddress { get; set; }
        //public string LastLocation { get; set; }
        //public DateTime? LastLoginDate { get; set; }

        public FeaturesDto FeaturesDto { get; set; }

        [Display(Name = "Notes", Prompt = "Notes")]
        public string Description { get; set; }

    }
}
