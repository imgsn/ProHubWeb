using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProHub.Domain.Dtos.Accounts;
using ProHub.Domain.Dtos.Establishments;
using ProHub.Domain.Entities;

namespace ProHub.Domain.Helpers
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
