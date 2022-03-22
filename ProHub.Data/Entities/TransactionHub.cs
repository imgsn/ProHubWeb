using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Data.Base;

namespace ProHub.Data.Entities
{
    public class TransactionHub : IHasKey, IHasDelete, IHasAudit
    {
        public int Id { get; set; }
        public int EstablishmentId { get; set; }
        public int DocumentId { get; set; }
        public DateTime TransferDate { get; set; }
        public string BankName { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string Notes { get; set; }
        public double TotalAmount { get; set; }



        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
