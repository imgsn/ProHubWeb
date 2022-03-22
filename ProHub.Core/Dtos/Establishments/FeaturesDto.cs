using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Core.Dtos.Establishments
{
    public class FeaturesDto
    {
        public int UserCount { get; set; }
        public int ValidationMinutes { get; set; }
        public bool IsAttendance { get; set; }
        public bool IsSales { get; set; }
        public bool IsSupport { get; set; }
        public bool IsLocation { get; set; }
        public bool IsDistribution { get; set; }
    }
}
