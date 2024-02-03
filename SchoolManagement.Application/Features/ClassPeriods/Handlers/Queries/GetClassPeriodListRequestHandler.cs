using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassPeriod;
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

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetClassPeriodListRequestHandler : IRequestHandler<GetClassPeriodListRequest, PagedResult<ClassPeriodDto>>
    {

        private readonly ISchoolManagementRepository<ClassPeriod> _ClassPeriodRepository;

        private readonly IMapper _mapper;

        public GetClassPeriodListRequestHandler(ISchoolManagementRepository<ClassPeriod> ClassPeriodRepository, IMapper mapper)
        {
            _ClassPeriodRepository = ClassPeriodRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ClassPeriodDto>> Handle(GetClassPeriodListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ClassPeriod> ClassPeriods = _ClassPeriodRepository.FilterWithInclude(x => (x.PeriodName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName", "BnaClassScheduleStatus");
            var totalCount = ClassPeriods.Count();
            ClassPeriods = ClassPeriods.OrderByDescending(x => x.ClassPeriodId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ClassPeriodDtos = _mapper.Map<List<ClassPeriodDto>>(ClassPeriods);
            var result = new PagedResult<ClassPeriodDto>(ClassPeriodDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
