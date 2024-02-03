﻿using AutoMapper;
using SchoolManagement.Application.DTOs.District;
using SchoolManagement.Application.Features.Districts.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Districts.Handlers.Queries
{
    public class GetDistrictDetailRequestHandler : IRequestHandler<GetDistrictDetailRequest, DistrictDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.District> _DistrictRepository;
        public GetDistrictDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.District> DistrictRepository, IMapper mapper)
        {
            _DistrictRepository = DistrictRepository;
            _mapper = mapper;
        }
        public async Task<DistrictDto> Handle(GetDistrictDetailRequest request, CancellationToken cancellationToken)
        {
            var District = await _DistrictRepository.Get(request.DistrictId);
            return _mapper.Map<DistrictDto>(District);
        }
    }
}
