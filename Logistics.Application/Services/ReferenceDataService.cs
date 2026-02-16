using AutoMapper;
using Logistics.Application.DTOs;
using Logistics.Application.Interfaces;
using Logistics.Infrastructure.Interface;
using Logistics.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IReferenceDataRepository _referenceDataRepository;
        private readonly IMapper _mapper;

        public ReferenceDataService(IReferenceDataRepository referenceDataRepository,
            IMapper mapper)
        {
            _referenceDataRepository = referenceDataRepository;
            _mapper = mapper;
        }

        public async Task<List<ReferenceDataDto>> GetAllReferenceDataAsync()
        {
            var list = await _referenceDataRepository.GetReferenceDataListAsync();
            return _mapper.Map<List<ReferenceDataDto>>(list);
        }
    }
}
