using ProHub.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Domain.Entities
{
    public class Establishment : IHasKey, IHasDelete, IHasLocal, IHasAudit, IHasCode
    {
        public string Code { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string FeaturesJson { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Description { get; set; }
        public int? CommercialDocumentId { get; set; }
        public int? LogoDocumentId { get; set; }


        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}
