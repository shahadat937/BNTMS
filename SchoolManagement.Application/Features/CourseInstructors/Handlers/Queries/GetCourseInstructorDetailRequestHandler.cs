using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetCourseInstructorDetailRequestHandler : IRequestHandler<GetCourseInstructorDetailRequest, CourseInstructorDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseInstructor> _CourseInstructorRepository;
        public GetCourseInstructorDetailRequestHandler(ISchoolManagementRepository<CourseInstructor> CourseInstructorRepository, IMapper mapper)
        {
            _CourseInstructorRepository = CourseInstructorRepository;
            _mapper = mapper;
        }
        public async Task<CourseInstructorDto> Handle(GetCourseInstructorDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseInstructor =  _CourseInstructorRepository.FinedOneInclude(x =>x.CourseInstructorId == request.CourseInstructorId, "Trainee", "CourseName", "CourseDuration");
            return _mapper.Map<CourseInstructorDto>(CourseInstructor);
        }
    }
}
