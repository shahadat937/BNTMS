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
            string trimmedSearchText = request.QueryParams.SearchText?.Trim() ?? string.Empty;
            string normalizedSearchText = System.Text.RegularExpressions.Regex.Replace(trimmedSearchText, @"\s+", "").ToLower();

            IQueryable<CourseDuration> courseDurationsQuery = _CourseDurationRepository.FilterWithInclude(
                x => (EF.Functions.Like((x.CourseName.Course.Trim() + " - " + x.CourseTitle.Trim()), $"%{trimmedSearchText}%") ||
                      x.BaseSchoolName.SchoolName.Contains(trimmedSearchText) ||
                      string.IsNullOrEmpty(trimmedSearchText)) &&
                     x.CourseTypeId == request.CourseTypeId,
                "BaseSchoolName", "CourseName", "OrganizationName"
            );

            DateTime today = DateTime.Now;

            switch (request.Status)
            {
                case 1: // Running courses
                    courseDurationsQuery = courseDurationsQuery.Where(x => x.IsCompletedStatus == 0 && x.DurationTo >= today);
                    break;
                case 2: // Passing-out courses
                    courseDurationsQuery = courseDurationsQuery.Where(x => x.IsCompletedStatus == 0 && x.DurationTo < today);
                    break;
                case 3: // Upcoming courses
                    courseDurationsQuery = courseDurationsQuery.Where(x => x.IsCompletedStatus == 0 && x.DurationFrom > today);
                    break;
                default: // All courses
                    courseDurationsQuery = courseDurationsQuery.Where(x => x.IsCompletedStatus == 0);
                    break;
            }

            // **Step 1: Get distinct schools (5 schools per page)**
            var schoolIdsQuery = courseDurationsQuery
                .Select(x => x.BaseSchoolNameId)
                .Distinct()
                .OrderBy(id => id); // Ensure stable ordering

            int totalSchools = await schoolIdsQuery.CountAsync(cancellationToken); // Total school count for pagination

            var paginatedSchoolIds = await schoolIdsQuery
                .Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize)
                .Take(request.QueryParams.PageSize)
                .ToListAsync(cancellationToken);

            // **Step 2: Get all courses belonging to those paginated schools**
            var filteredCourses = await courseDurationsQuery
                .Where(x => paginatedSchoolIds.Contains(x.BaseSchoolNameId))
                .OrderBy(x => x.BaseSchoolNameId)
                .ThenBy(x => x.CourseTitle) // Optional: Ensure consistent ordering
                .ToListAsync(cancellationToken);

            // **Step 3: Group by school**
            var groupedBySchool = filteredCourses
                .GroupBy(x => x.BaseSchoolNameId)
                .Select(g => new
                {
                    SchoolId = g.Key,
                    Courses = g.ToList()
                })
                .ToList();

            // **Map to DTOs**
            var courseDurationDtosList = groupedBySchool
                .SelectMany(school => school.Courses.Select(course => _mapper.Map<CourseDurationDto>(course)))
                .ToList();

            return new PagedResult<CourseDurationDto>(
                courseDurationDtosList,
                totalSchools, // Total number of distinct schools
                request.QueryParams.PageNumber,
                request.QueryParams.PageSize
            );
        }



    }
}
