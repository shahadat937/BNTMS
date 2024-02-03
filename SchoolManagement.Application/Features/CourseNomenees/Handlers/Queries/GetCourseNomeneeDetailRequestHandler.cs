using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Queries
{
    public class GetCourseNomeneeDetailRequestHandler : IRequestHandler<GetCourseNomeneeDetailRequest, CourseNomeneeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseNomenee> _CourseNomeneeRepository;
        public GetCourseNomeneeDetailRequestHandler(ISchoolManagementRepository<CourseNomenee> CourseNomeneeRepository, IMapper mapper)
        {
            _CourseNomeneeRepository = CourseNomeneeRepository;
            _mapper = mapper;
        }
        public async Task<CourseNomeneeDto> Handle(GetCourseNomeneeDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseNomenee =  _CourseNomeneeRepository.FinedOneInclude(x =>x.CourseNomeneeId == request.CourseNomeneeId, "Trainee", "CourseName", "CourseDuration");
            return _mapper.Map<CourseNomeneeDto>(CourseNomenee);
        }
    }
}
