using AutoMapper;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Queries;
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

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Handlers.Queries
{
    public class GetEmploymentBeforeJoinBnaListRequestHandler : IRequestHandler<GetEmploymentBeforeJoinBnaListRequest, PagedResult<EmploymentBeforeJoinBnaDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EmploymentBeforeJoinBna> _EmploymentBeforeJoinBnaRepository;

        private readonly IMapper _mapper;

        public GetEmploymentBeforeJoinBnaListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EmploymentBeforeJoinBna> EmploymentBeforeJoinBnaRepository, IMapper mapper)
        {
            _EmploymentBeforeJoinBnaRepository = EmploymentBeforeJoinBnaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EmploymentBeforeJoinBnaDto>> Handle(GetEmploymentBeforeJoinBnaListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.EmploymentBeforeJoinBna> EmploymentBeforeJoinBnas = _EmploymentBeforeJoinBnaRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = EmploymentBeforeJoinBnas.Count();
            EmploymentBeforeJoinBnas = EmploymentBeforeJoinBnas.OrderByDescending(x => x.EmploymentBeforeJoinBnaId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var EmploymentBeforeJoinBnaDtos = _mapper.Map<List<EmploymentBeforeJoinBnaDto>>(EmploymentBeforeJoinBnas);
            var result = new PagedResult<EmploymentBeforeJoinBnaDto>(EmploymentBeforeJoinBnaDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
