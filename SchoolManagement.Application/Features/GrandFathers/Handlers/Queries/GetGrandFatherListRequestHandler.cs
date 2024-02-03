using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFather;
using SchoolManagement.Application.Features.GrandFathers.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.GrandFathers.Handlers.Queries
{
    public class GetGrandFatherListRequestHandler : IRequestHandler<GetGrandFatherListRequest, PagedResult<GrandFatherDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GrandFather> _GrandFatherRepository;

        private readonly IMapper _mapper;

        public GetGrandFatherListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GrandFather> GrandFatherRepository, IMapper mapper)
        {
            _GrandFatherRepository = GrandFatherRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GrandFatherDto>> Handle(GetGrandFatherListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.GrandFather> GrandFathers = _GrandFatherRepository.FilterWithInclude(x => (x.GrandFathersName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "GrandFatherType", "Occupation", "Nationality");
            var totalCount = GrandFathers.Count();
            GrandFathers = GrandFathers.OrderByDescending(x => x.GrandFatherId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GrandFatherDtos = _mapper.Map<List<GrandFatherDto>>(GrandFathers);
            var result = new PagedResult<GrandFatherDto>(GrandFatherDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
