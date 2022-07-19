﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Data.Base;

namespace ProHub.Data.Entities
{
    public class ProductHub : IHasKey, IHasDelete, IHasAudit
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int EstablishmentId { get; set; }


        public bool IsActive { get; set; }
        public string InsertUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


        public virtual Establishment Establishment { get; set; }


    }
}
