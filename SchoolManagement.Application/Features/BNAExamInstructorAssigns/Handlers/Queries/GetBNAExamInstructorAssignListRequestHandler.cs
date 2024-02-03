using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
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

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Handlers.Queries
{
    public class GetBnaExamInstructorAssignListRequestHandler : IRequestHandler<GetBnaExamInstructorAssignListRequest, PagedResult<BnaExamInstructorAssignDto>>
    {

        private readonly ISchoolManagementRepository<BnaExamInstructorAssign> _BnaExamInstructorAssignRepository;

        private readonly IMapper _mapper;

        public GetBnaExamInstructorAssignListRequestHandler(ISchoolManagementRepository<BnaExamInstructorAssign> BnaExamInstructorAssignRepository, IMapper mapper)
        {
            _BnaExamInstructorAssignRepository = BnaExamInstructorAssignRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaExamInstructorAssignDto>> Handle(GetBnaExamInstructorAssignListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaExamInstructorAssign> BnaExamInstructorAssigns = _BnaExamInstructorAssignRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName", "BnaInstructorType", "BnaSubjectName", "ClassRoutine", "CourseDuration", "CourseModule", "CourseName", "Trainee.Rank");
            var totalCount = BnaExamInstructorAssigns.Count();
            BnaExamInstructorAssigns = BnaExamInstructorAssigns.OrderByDescending(x => x.BnaExamInstructorAssignId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaExamInstructorAssignDtos = _mapper.Map<List<BnaExamInstructorAssignDto>>(BnaExamInstructorAssigns);
            var result = new PagedResult<BnaExamInstructorAssignDto>(BnaExamInstructorAssignDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
