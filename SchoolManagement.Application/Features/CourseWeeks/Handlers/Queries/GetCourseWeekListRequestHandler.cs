using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetCourseWeekListRequestHandler : IRequestHandler<GetCourseWeekListRequest, PagedResult<CourseWeekDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseWeek> _CourseWeekRepository;

        private readonly IMapper _mapper;

        public GetCourseWeekListRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository, IMapper mapper)
        {
            _CourseWeekRepository = CourseWeekRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseWeekDto>> Handle(GetCourseWeekListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CourseWeek> CourseWeeks = _CourseWeekRepository.FilterWithInclude(x => (x.WeekName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseDuration", "BaseSchoolName", "CourseName").Where(x=>x.BaseSchoolNameId==request.BaseSchoolNameId && x.CourseDurationId==request.CourseDurationId && x.CourseDuration.IsCompletedStatus == 0).OrderBy(x=>x.DateFrom);
            var totalCount = CourseWeeks.Count();
            CourseWeeks = CourseWeeks.OrderBy(x => x.DateFrom).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseWeekDtos = _mapper.Map<List<CourseWeekDto>>(CourseWeeks);
            var result = new PagedResult<CourseWeekDto>(CourseWeekDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
