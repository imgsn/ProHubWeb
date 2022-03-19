using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Domain.Base;

namespace ProHub.Domain.Entities
{
    public class MessageHub : IHasKey, IHasAudit, IHasDelete
    {
        public int Id { get; set; }
        public int EstablishmentId { get; set; }
        public virtual Establishment Establishment { get; set; }

        public string Subject { get; set; }
        public string MessageBody { get; set; }



        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
