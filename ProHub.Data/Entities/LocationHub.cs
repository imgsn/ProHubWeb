﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Data.Base;

namespace ProHub.Data.Entities
{
    public class LocationHub : IHasKey, IHasLocal, IHasAudit, IHasDelete
    {

        public int Id { get; set; }
        public int EstablishmentId { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? CityId { get; set; }
        public int? CategoryId { get; set; }
        public int LocationTypeId { get; set; }

        public string Description { get; set; }
        public string AddressStr { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double BufferArea { get; set; }
        public bool IsGps { get; set; }






        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Establishment Establishment { get; set; }
    }
}
