using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationListForMistRequestHandler : IRequestHandler<GetCourseDurationListForMistRequest, PagedResult<CourseDurationDto>>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;

        public GetCourseDurationListForMistRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseDurationDto>> Handle(GetCourseDurationListForMistRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => (x.CourseTitle.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "BaseSchoolName", "OrganizationName");
            var totalCount = CourseDurations.Count();
            CourseDurations = CourseDurations.OrderByDescending(x => x.CourseDurationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x=> x.CourseTypeId == 1022 && x.IsCompletedStatus==0);

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);
            var result = new PagedResult<CourseDurationDto>(CourseDurationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
