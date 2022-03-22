using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProHub.Data.Entities
{

    public class AccountUserClaim : IdentityUserClaim<string>
    {
        public virtual Account User { get; set; }
    }
}
