using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Data.Base
{
    public interface IHasDelete
    {
          bool IsActive { get; set; }
    }
}
