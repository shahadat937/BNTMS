using SchoolManagement.Application.Features.CoursePlans.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CoursePlan;
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

using System.Text;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Queries
{
    public class GetCoursePlanListRequestHandler : IRequestHandler<GetCoursePlanListRequest, PagedResult<CoursePlanDto>>
    {

        private readonly ISchoolManagementRepository<CoursePlanCreate> _CoursePlanRepository;

        private readonly IMapper _mapper;

        public GetCoursePlanListRequestHandler(ISchoolManagementRepository<CoursePlanCreate> CoursePlanRepository, IMapper mapper)
        {
            _CoursePlanRepository = CoursePlanRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CoursePlanDto>> Handle(GetCoursePlanListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CoursePlanCreate> CoursePlans = _CoursePlanRepository.FilterWithInclude(x => (x.CoursePlanName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName","CourseName", "CourseDuration"); 
            var totalCount = CoursePlans.Count();
            CoursePlans = CoursePlans.OrderByDescending(x => x.CoursePlanCreateId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CoursePlanDtos = _mapper.Map<List<CoursePlanDto>>(CoursePlans);
            var result = new PagedResult<CoursePlanDto>(CoursePlanDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
