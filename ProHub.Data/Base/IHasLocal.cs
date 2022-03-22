using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Data.Base
{
    public interface IHasLocal
    {
        string ArName { get; set; }
        string EnName { get; set; }
    }
}
