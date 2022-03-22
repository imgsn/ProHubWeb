using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProHub.Data.Entities
{
    public class AccountUserRole : IdentityUserRole<string>
    {
        public DateTime AssignDate { get; set; } = DateTime.Now;
        public virtual Account User { get; set; }
        public virtual AccountRole UserRole { get; set; }
    }
}
