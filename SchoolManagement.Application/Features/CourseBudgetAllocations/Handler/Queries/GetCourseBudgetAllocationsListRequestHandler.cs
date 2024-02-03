using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handler.Queries
{
    public class GetCourseBudgetAllocationListRequestHandler : IRequestHandler<GetCourseBudgetAllocationListRequest, PagedResult<CourseBudgetAllocationDto>>
    { 

        private readonly ISchoolManagementRepository<CourseBudgetAllocation> _CourseBudgetAllocationRepository; 

        private readonly IMapper _mapper;

        public GetCourseBudgetAllocationListRequestHandler(ISchoolManagementRepository<CourseBudgetAllocation> CourseBudgetAllocationRepository, IMapper mapper)
        {
            _CourseBudgetAllocationRepository = CourseBudgetAllocationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseBudgetAllocationDto>> Handle(GetCourseBudgetAllocationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<CourseBudgetAllocation> CourseBudgetAllocationes = _CourseBudgetAllocationRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "Trainee", "BudgetCode", "PaymentType").Where(x=>x.CourseNameId ==request.CourseNameId && x.TraineeId == request.TraineeId);
            var totalCount = CourseBudgetAllocationes.Count();
            CourseBudgetAllocationes = CourseBudgetAllocationes.OrderByDescending(x => x.CourseBudgetAllocationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseBudgetAllocationesDtos = _mapper.Map<List<CourseBudgetAllocationDto>>(CourseBudgetAllocationes);
            var result = new PagedResult<CourseBudgetAllocationDto>(CourseBudgetAllocationesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
