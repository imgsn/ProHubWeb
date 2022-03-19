using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProHub.Domain.Dtos.Establishments;
using ProHub.Domain.Entities;
using ProHub.Domain.Extensions;
using ProHub.Domain.Helpers;
using ProHub.Domain.UnitofWork;
using X.PagedList;

namespace ProHub.Domain.Services.Establishments
{
    public class EstablishmentServices : IEstablishmentServices
    {
        private readonly IMapper _mapperHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EstablishmentServices> _logger;


        public EstablishmentServices(
            IMapper mapperHelper,
            IUnitOfWork unitOfWork,
            ILogger<EstablishmentServices> logger)
        {
            _mapperHelper = mapperHelper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public async Task<List<EstablishmentDto>> GetEstablishmentDtoList()
        {
            var establishments = await _unitOfWork.RepositoryOf<Establishment>().AllIncludeAsync();
            return _mapperHelper.Map<List<EstablishmentDto>>(establishments);
        }

        public async Task<bool> AddEstablishment(Establishment establishment)
        {
            _unitOfWork.RepositoryOf<Establishment>().Insert(establishment);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> AddEstablishment(EstablishmentDto establishmentDto)
        {
            var establishment = _mapperHelper.Map<Establishment>(establishmentDto);
            _unitOfWork.RepositoryOf<Establishment>().Insert(establishment);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IPagedList<EstablishmentDto>> GetEstablishmentDtoPagedList(int page = 1)
        {
            var establishments = await _unitOfWork.RepositoryOf<Establishment>()
                .FindPagedAsync(pageNum: page, disableTracking: true);
            return establishments.ToMapPagedList<Establishment, EstablishmentDto>(_mapperHelper);
        }



    }
}
