﻿using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Country;
using SchoolManagement.Application.Features.Countrys.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Countrys.Handlers.Queries
{
    public class GetCountryDetailRequestHandler : IRequestHandler<GetCountryDetailRequest, CountryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Country> _CountryRepository;
        public GetCountryDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Country> CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }
        public async Task<CountryDto> Handle(GetCountryDetailRequest request, CancellationToken cancellationToken)
        {
            var Country = await _CountryRepository.Get(request.CountryId);
            return _mapper.Map<CountryDto>(Country);
        }
    }
}
