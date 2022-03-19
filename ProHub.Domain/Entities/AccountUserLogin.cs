using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProHub.Domain.Entities
{
    public class AccountUserLogin : IdentityUserLogin<string>
    {
        public virtual Account User { get; set; }
    }
}
