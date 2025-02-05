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
    public class GetCourseDurationByCourseTypeIdWithOutGroupByRequestHandler : IRequestHandler<GetCourseDurationByCourseTypeIdWithOutGroupByRequest, PagedResult<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;
        public GetCourseDurationByCourseTypeIdWithOutGroupByRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        

        public async Task<PagedResult<CourseDurationDto>> Handle(GetCourseDurationByCourseTypeIdWithOutGroupByRequest request, CancellationToken cancellationToken)
        {
            string trimmedSearchText = request.QueryParams.SearchText?.Trim() ?? string.Empty;
            string normalizedSearchText = System.Text.RegularExpressions.Regex.Replace(trimmedSearchText, @"\s+", "").ToLower();

            IQueryable<CourseDuration> courseDurationsQuery = _CourseDurationRepository.FilterWithInclude(
                x => (EF.Functions.Like((x.CourseName.Course.Trim() + " - " + x.CourseTitle.Trim()), $"%{trimmedSearchText}%") ||
                      x.BaseSchoolName.SchoolName.Contains(trimmedSearchText) ||
                      string.IsNullOrEmpty(trimmedSearchText)) &&
                     x.CourseTypeId == request.CourseTypeId,
                "BaseSchoolName", "CourseName", "OrganizationName","Country"
            );

            DateTime today = DateTime.Now;


            switch (request.Status)
            {
                case 1: // Running courses
                    courseDurationsQuery = courseDurationsQuery.Where(x => x.IsCompletedStatus == 0 && x.DurationTo >= today);
                    break;
                case 2: // Passing-out courses
                    courseDurationsQuery = courseDurationsQuery.Where(x =>  x.DurationTo < today);
                    break;
                case 3: // Upcoming courses
                    courseDurationsQuery = courseDurationsQuery.Where(x =>  x.DurationFrom > today);
                    break;
                default: // All courses
                    courseDurationsQuery = courseDurationsQuery;
                    break;
            }

            var totalCount = await courseDurationsQuery.CountAsync(cancellationToken);


            // Pagination
            var courses = courseDurationsQuery.OrderByDescending(x=> x.DateCreated)
                .Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize)
                .Take(request.QueryParams.PageSize);

            var courseDurationDtos = _mapper.Map<List<CourseDurationDto>>(courses);


            return new PagedResult<CourseDurationDto>(
                courseDurationDtos,
                totalCount,
                request.QueryParams.PageNumber,
                request.QueryParams.PageSize
            );
        }


    }
}
