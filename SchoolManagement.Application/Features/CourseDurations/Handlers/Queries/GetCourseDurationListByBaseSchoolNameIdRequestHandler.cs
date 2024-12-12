using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationListByBaseSchoolNameIdRequestHandler : IRequestHandler<GetCourseDurationListByBaseSchoolNameIdRequest, List<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;
        private readonly IMapper _mapper;

        public GetCourseDurationListByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDurationDto>> Handle(GetCourseDurationListByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(
                x => x.IsCompletedStatus == 0,
                "CourseName", "BaseSchoolName"
            );


            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                //string searchTerm = request.SearchTerm.Trim().ToLower();
                string normalizedSearchText = System.Text.RegularExpressions.Regex.Replace(request.SearchTerm, @"\s+", "").ToLower();

                CourseDurations = CourseDurations.Where(x =>
                    EF.Functions.Like(
                    (x.CourseName.Course.Trim() + " - " + x.CourseTitle.Trim()).Replace(" ", "").ToLower(),
                    $"%{normalizedSearchText}%") ||
                    (x.CourseName.Course.Contains(request.SearchTerm) ||
                    x.CourseTitle.Contains(request.SearchTerm))
                );
            }


            if (request.BaseSchoolNameId != null)
            {
                CourseDurations = CourseDurations.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId);
            }

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);

            return CourseDurationDtos;
        }
    }


}
