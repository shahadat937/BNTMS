using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationByCourseTypeIdRequestHandler : IRequestHandler<GetCourseDurationByCourseTypeIdRequest, PagedResult<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;
        public GetCourseDurationByCourseTypeIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseDurationDto>> Handle(GetCourseDurationByCourseTypeIdRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            //var validationResult = await validator.ValidateAsync(request.QueryParams);

            // if (validationResult.IsValid == false)
            // throw new ValidationException(validationResult);


            string trimmedSearchText = request.QueryParams.SearchText?.Trim() ?? string.Empty;


            string normalizedSearchText = System.Text.RegularExpressions.Regex.Replace(trimmedSearchText, @"\s+", "").ToLower();

            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x =>
                EF.Functions.Like((x.CourseName.Course.Trim() + " - " + x.CourseTitle.Trim()).Replace(" ", "").ToLower(), $"%{normalizedSearchText}%") ||
                x.BaseSchoolName.SchoolName.Contains(trimmedSearchText) ||
                string.IsNullOrEmpty(trimmedSearchText),
                "BaseSchoolName", "CourseName", "OrganizationName")
                .Where(x => x.CourseTypeId == request.CourseTypeId);





            DateTime today = DateTime.Now;

            if (request.Status == 1)
            {
                // Running Local Course
                CourseDurations = CourseDurations.Where(x => x.CourseTypeId == request.CourseTypeId && x.IsCompletedStatus == 0 && x.DurationFrom <= today && x.DurationTo >= today).OrderBy(x => x.IsCompletedStatus);
                //.Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
            }
            else if (request.Status == 2)
            {
                var groupedBySchool = CourseDurations
                    .Where(x => x.CourseTypeId == request.CourseTypeId
                    && x.IsCompletedStatus == 0
                    && x.DurationTo < today)
                    .GroupBy(x => x.BaseSchoolNameId)
                    .Select(g => new
                    {
                        SchoolId = g.Key,
                        Courses = g.ToList()
                    });
               
                var paginatedSchools = groupedBySchool
                    .Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize)
                    .Take(request.QueryParams.PageSize)
                    .ToList();


                var CourseDurationDtosList = paginatedSchools.SelectMany(school =>
                    school.Courses.Select(course => _mapper.Map<CourseDurationDto>(course))
                ).ToList();
               
                return new PagedResult<CourseDurationDto>(
                    CourseDurationDtosList,
                    0,
                    request.QueryParams.PageNumber,
                    request.QueryParams.PageSize
                );

            }
            else if (request.Status == 3)
            {
                // UpComing Course
                CourseDurations = CourseDurations.Where(x => x.CourseTypeId == request.CourseTypeId && x.IsCompletedStatus == 0 && x.DurationFrom > today).OrderBy(x => x.IsCompletedStatus);
                //Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            }
            else
            {
                // All Course 
                CourseDurations = CourseDurations.Where(x => x.CourseTypeId == request.CourseTypeId && x.IsCompletedStatus == 0).OrderBy(x => x.IsCompletedStatus);
                //.Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            }


            //var totalCount = CourseDurations.Count();




            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);
            var result = new PagedResult<CourseDurationDto>(CourseDurationDtos, 0, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }

    }
}
