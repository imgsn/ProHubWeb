using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Domain.Dtos.Accounts
{
    public class RoleDto
    {
        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "RoleId", Prompt = "RoleId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Err_Required")]
        [Display(Name = "RoleName", Prompt = "RoleName")]
        public string RoleName { get; set; }

    }
}
