using ProHub.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Domain.Entities
{
    public class DocumentHub : IHasKey, IHasAudit, IHasDelete
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual LookupItem DocumentType { get; set; }

        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
