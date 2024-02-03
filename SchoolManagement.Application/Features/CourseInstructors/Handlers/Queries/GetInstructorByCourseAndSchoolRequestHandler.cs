using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetInstructorByCourseAndSchoolRequestHandler : IRequestHandler<GetInstructorByCourseAndSchoolRequest, List<CourseInstructorDto>>
    {
        private readonly ISchoolManagementRepository<CourseInstructor> _CourseInstructorRepository;

        private readonly IMapper _mapper;
        public GetInstructorByCourseAndSchoolRequestHandler(ISchoolManagementRepository<CourseInstructor> CourseInstructorRepository, IMapper mapper)
        {
            _CourseInstructorRepository = CourseInstructorRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseInstructorDto>> Handle(GetInstructorByCourseAndSchoolRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseInstructor> CourseInstructors = _CourseInstructorRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseDurationId == request.CourseDurationId && x.CourseNameId == request.CourseNameId && x.Status == 0, "CourseDuration", "BaseSchoolName", "CourseName", "BnaSubjectName", "CourseModule", "Trainee.Rank").OrderBy(x => x.CourseModule.MenuPosition);
            //var CourseInstructors = _CourseInstructorRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.CourseInstructorId);

            var CourseInstructorDtos = _mapper.Map<List<CourseInstructorDto>>(CourseInstructors);

            return CourseInstructorDtos;
        }
        
    }
}
