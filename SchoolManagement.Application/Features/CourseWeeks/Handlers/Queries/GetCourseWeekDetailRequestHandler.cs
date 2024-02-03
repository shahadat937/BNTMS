using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetCourseWeekDetailRequestHandler : IRequestHandler<GetCourseWeekDetailRequest, CourseWeekDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseWeek> _CourseWeekRepository;
        public GetCourseWeekDetailRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository, IMapper mapper)
        {
            _CourseWeekRepository = CourseWeekRepository;
            _mapper = mapper;
        }
        public async Task<CourseWeekDto> Handle(GetCourseWeekDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseWeek = _CourseWeekRepository.FinedOneInclude(x=>x.CourseWeekId==request.CourseWeekId, "CourseName", "CourseDuration");
            return _mapper.Map<CourseWeekDto>(CourseWeek);
        }
    }
}
