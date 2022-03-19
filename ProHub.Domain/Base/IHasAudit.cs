using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Domain.Base
{
    public interface IHasAudit
    {
        string InsertUserId { get; set; }
        string UpdateUserId { get; set; }
        DateTime InsertDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}


