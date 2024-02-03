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
    public class GetCourseInstructorByParametersRequestHandler : IRequestHandler<GetCourseInstructorByParametersRequest, List<CourseInstructorDto>>
    {
        private readonly ISchoolManagementRepository<CourseInstructor> _CourseInstructorRepository;

        private readonly IMapper _mapper;
        public GetCourseInstructorByParametersRequestHandler(ISchoolManagementRepository<CourseInstructor> CourseInstructorRepository, IMapper mapper)
        {
            _CourseInstructorRepository = CourseInstructorRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseInstructorDto>> Handle(GetCourseInstructorByParametersRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseInstructor> CourseInstructors = _CourseInstructorRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.CourseModuleId == request.CourseModuleId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId,"CourseDuration", "BaseSchoolName", "CourseName", "BnaSubjectName", "MarkType", "CourseModule", "Trainee", "Trainee.Rank", "Trainee.SaylorRank").OrderBy(x=>x.Status);
            //var CourseInstructors = _CourseInstructorRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.CourseInstructorId);

            var CourseInstructorDtos = _mapper.Map<List<CourseInstructorDto>>(CourseInstructors);

            return CourseInstructorDtos;
        }
        
    }
}
