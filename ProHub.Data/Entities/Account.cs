using Microsoft.AspNetCore.Identity;
using ProHub.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Data.Entities
{
    public class Account : IdentityUser<string>, IHasAudit, IHasDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public int? EstablishmentId { get; set; }
        public string ActivationKey { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ProfileDocumentId { get; set; }
        public int? IdentityDocumentId { get; set; }
        public string FeaturesJson { get; set; }
        public int? BranchId { get; set; }
        public int? JobTitleId { get; set; }
        public string Description { get; set; }
        public string DeviceToken { get; set; }
        public DateTime? TokenDate { get; set; }
        public DateTime? LastLocationDate { get; set; }
        public string LastLocationAddress { get; set; }
        public string LastLocation { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public virtual Establishment Establishment { get; set; }


        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


        public virtual ICollection<AccountUserClaim> Claims { get; set; }
        public virtual ICollection<AccountUserLogin> Logins { get; set; }
        public virtual ICollection<AccountUserToken> Tokens { get; set; }
        public virtual ICollection<AccountUserRole> UserRoles { get; set; }
    }
}
