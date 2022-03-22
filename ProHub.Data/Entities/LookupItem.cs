using ProHub.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Data.Entities
{
    public class LookupItem : IHasKey, IHasAudit, IHasDelete, IHasLocal
    {
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int OrderIndex { get; set; }
        public int LookupGroupId { get; set; }
        public int SubLookupId { get; set; }
        public string Description { get; set; }


        public virtual LookupGroup LookupGroup { get; set; }
        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
