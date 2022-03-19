using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProHub.Domain.Entities
{
    public class AccountRoleClaim : IdentityRoleClaim<string>
    {
        public virtual AccountRole Role { get; set; }
    }
}
