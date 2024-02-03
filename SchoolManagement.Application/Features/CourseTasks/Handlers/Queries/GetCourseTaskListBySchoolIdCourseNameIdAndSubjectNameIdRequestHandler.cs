using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Application.Features.CourseTasks.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Queries
{
    public class GetCourseTaskListBySchoolIdCourseNameIdAndSubjectNameIdRequestHandler : IRequestHandler<GetCourseTaskListBySchoolIdCourseNameIdAndSubjectNameIdRequest, List<CourseTaskDto>>
    {
        private readonly ISchoolManagementRepository<CourseTask> _CourseTaskRepository;
        private readonly IMapper _mapper;

        public GetCourseTaskListBySchoolIdCourseNameIdAndSubjectNameIdRequestHandler(ISchoolManagementRepository<CourseTask> CourseTaskRepository, IMapper mapper)
        {
            _CourseTaskRepository = CourseTaskRepository;
            _mapper = mapper;
        }
         
        public async Task<List<CourseTaskDto>> Handle(GetCourseTaskListBySchoolIdCourseNameIdAndSubjectNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseTask> CourseTasks = _CourseTaskRepository.FilterWithInclude(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId , "BaseSchoolName", "CourseName", "BnaSubjectName").ToList();
            
            var CourseTaskDtos = _mapper.Map<List<CourseTaskDto>>(CourseTasks);
            return CourseTaskDtos; 
        }
    }
}
