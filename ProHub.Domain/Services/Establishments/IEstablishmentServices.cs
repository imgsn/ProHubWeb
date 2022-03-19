using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Domain.Dtos.Establishments;
using ProHub.Domain.Entities;
using X.PagedList;

namespace ProHub.Domain.Services.Establishments
{
    public interface IEstablishmentServices : IDisposable
    {
        Task<List<EstablishmentDto>> GetEstablishmentDtoList();
        Task<bool> AddEstablishment(Establishment establishment);
        Task<bool> AddEstablishment(EstablishmentDto establishmentDto);
        Task<IPagedList<EstablishmentDto>> GetEstablishmentDtoPagedList(int page = 1);
    }
}
