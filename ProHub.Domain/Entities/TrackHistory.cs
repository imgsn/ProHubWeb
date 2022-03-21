using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Domain.Base;

namespace ProHub.Domain.Entities
{
    public class TrackHistory : IHasKey
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string DeviceImei { get; set; }
        public string Version { get; set; }
        public DateTime LocationDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AddressStr { get; set; }
        public DateTime InsertDate { get; set; }

    }
}
