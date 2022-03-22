using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProHub.Data.Entities
{
    public class AccountRole : IdentityRole<string>
    {
        public string RoleDescription { get; set; }

        public virtual ICollection<AccountUserRole> UserRoles { get; set; }
        public virtual ICollection<AccountRoleClaim> RoleClaims { get; set; }
    }
}
