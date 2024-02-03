using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetForeignCourseListByCountryIdRequestHandler : IRequestHandler<GetForeignCourseListByCountryIdRequest, List<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;
        public GetForeignCourseListByCountryIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDurationDto>> Handle(GetForeignCourseListByCountryIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> courseDurations = _CourseDurationRepository.FilterWithInclude(x => x.CountryId == request.CountryId && x.CourseTypeId==18, "Country", "CourseName").OrderBy(x => x.IsCompletedStatus);

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(courseDurations);

            return CourseDurationDtos; 
        }

    }
}
