using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Domain.Dtos.Establishments
{
    public class EstablishmentDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "ArName")]
        public string ArName { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "EnName", Prompt = "EnName")]
        public string EnName { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "Address", Prompt = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "PhoneNumber", Prompt = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "FaxNumber", Prompt = "FaxNumber")]
        public string FaxNumber { get; set; }



        //[Required(ErrorMessage = "Err_Required")]
        //[Display(Name = "Features", Prompt = "Features")]
        //public string Features { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "ExpiryDate", Prompt = "ExpiryDate")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "IsActive", Prompt = "IsActive")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "Description", Prompt = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "EncryptionKey", Prompt = "EncryptionKey")]
        public string EncryptionKey { get; set; }
        public string CreatedUserId { get; set; }
        public string UpdatedUserId { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "CreatedDate", Prompt = "CreatedDate")]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public FeaturesDto Features { get; set; }

    }
}
