using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetInterServiceCourseListByCourseNameIdAndOrganizationNameIdRequestHandler : IRequestHandler<GetInterServiceCourseListByCourseNameIdAndOrganizationNameIdRequest, List<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;
        public GetInterServiceCourseListByCourseNameIdAndOrganizationNameIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDurationDto>> Handle(GetInterServiceCourseListByCourseNameIdAndOrganizationNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> courseDurations = _CourseDurationRepository.FilterWithInclude(x => x.CourseNameId == request.CourseNameId && x.OrganizationNameId == request.OrganizationNameId && x.CourseTypeId==19 && x.IsCompletedStatus ==0, "CourseName", "OrganizationName");

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(courseDurations);

            return CourseDurationDtos; 
        }

    }
}
