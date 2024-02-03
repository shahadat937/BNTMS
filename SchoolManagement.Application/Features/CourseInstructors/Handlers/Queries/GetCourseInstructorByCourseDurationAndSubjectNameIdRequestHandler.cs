using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetCourseInstructorByCourseDurationAndSubjectNameIdRequestHandler : IRequestHandler<GetCourseInstructorByCourseDurationAndSubjectNameIdRequest, List<CourseInstructorDto>>
    {
        private readonly ISchoolManagementRepository<CourseInstructor> _CourseInstructorRepository;

        private readonly IMapper _mapper;
        public GetCourseInstructorByCourseDurationAndSubjectNameIdRequestHandler(ISchoolManagementRepository<CourseInstructor> CourseInstructorRepository, IMapper mapper)
        {
            _CourseInstructorRepository = CourseInstructorRepository;
            _mapper = mapper;
        }
         
        public async Task<List<CourseInstructorDto>> Handle(GetCourseInstructorByCourseDurationAndSubjectNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseInstructor> CourseInstructors = _CourseInstructorRepository.FilterWithInclude(x => x.BnaSubjectNameId == request.BnaSubjectNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId,"CourseDuration", "BaseSchoolName", "CourseName", "BnaSubjectName", "CourseModule", "Trainee.Rank").OrderBy(x=>x.Status);

            var CourseInstructorDtos = _mapper.Map<List<CourseInstructorDto>>(CourseInstructors);

            return CourseInstructorDtos;
        }
        
    }
}
