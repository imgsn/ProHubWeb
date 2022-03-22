using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Core.Dtos.Establishments;
using ProHub.Data.Entities;
using X.PagedList;

namespace ProHub.Core.Services.Establishments
{
    public interface IEstablishmentServices : IDisposable
    {
        Task<List<EstablishmentDto>> GetEstablishmentDtoList();
        Task<bool> AddEstablishment(Establishment establishment);
        Task<bool> AddEstablishment(EstablishmentDto establishmentDto);
        Task<IPagedList<EstablishmentDto>> GetEstablishmentDtoPagedList(int page = 1);
    }
}
