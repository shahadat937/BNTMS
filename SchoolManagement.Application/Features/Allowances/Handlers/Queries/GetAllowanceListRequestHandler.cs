using SchoolManagement.Application.Features.Allowances.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Allowance;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Allowances.Handlers.Queries
{
    public class GetAllowanceListRequestHandler : IRequestHandler<GetAllowanceListRequest, PagedResult<AllowanceDto>>
    {

        private readonly ISchoolManagementRepository<Allowance> _AllowanceRepository;

        private readonly IMapper _mapper;

        public GetAllowanceListRequestHandler(ISchoolManagementRepository<Allowance> AllowanceRepository, IMapper mapper)
        {
            _AllowanceRepository = AllowanceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AllowanceDto>> Handle(GetAllowanceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Allowance> Allowances = _AllowanceRepository.FilterWithInclude(x => (x.Vacancy.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "FromRank", "ToRank", "Country", "CourseName");
            var totalCount = Allowances.Count();
            Allowances = Allowances.OrderByDescending(x => x.AllowanceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AllowanceDtos = _mapper.Map<List<AllowanceDto>>(Allowances);
            var result = new PagedResult<AllowanceDto>(AllowanceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
