using ProHub.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Data.Entities
{
    public class LookupGroup : IHasKey, IHasLocal
    {
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }

        public virtual ICollection<LookupItem> LookupItems { get; set; }
    }
}
//WeekDays
//Visit Status
//TimeZone
