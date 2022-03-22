using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProHub.Core.Dtos.Accounts;
using ProHub.Data.Entities;
using X.PagedList;

namespace ProHub.Core.Helpers
{
    public class MapperHelper : Profile
    {
        public MapperHelper()
        {
            CreateMap<AccountDto, Account>()
                //.ForMember(x => x.InsertDate, y
                //    => y.MapFrom(a => DateTime.Now))
                .ForMember(x => x.UserName, y
                    => y.MapFrom(a => a.Email))
                .ForMember(x => x.Id, y
                    => y.Ignore())
                .ForMember(x => x.FeaturesJson, y
                    => y.Ignore())

                .ReverseMap();

        }

    }
}
