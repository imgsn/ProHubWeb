using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProHub.Core.Dtos.Accounts;
using ProHub.Core.Dtos.Establishments;
using ProHub.Data.Entities;

namespace ProHub.Core.Helpers
{
    public class HubProfileHelper : Profile
    {
        public HubProfileHelper()
        {
            CreateMap<Establishment, EstablishmentDto>().ReverseMap();
            CreateMap<AccountDto, Account>().ReverseMap();
        }
    }
}
