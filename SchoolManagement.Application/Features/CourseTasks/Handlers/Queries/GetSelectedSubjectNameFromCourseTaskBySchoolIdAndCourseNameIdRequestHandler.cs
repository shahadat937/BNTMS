using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseTasks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Queries
{
    public class GetSelectedSubjectNameFromCourseTaskBySchoolIdAndCourseNameIdRequestHandler : IRequestHandler<GetSelectedSubjectNameFromCourseTaskBySchoolIdAndCourseNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseTask> _CourseTaskRepository;


        public GetSelectedSubjectNameFromCourseTaskBySchoolIdAndCourseNameIdRequestHandler(ISchoolManagementRepository<CourseTask> CourseTaskRepository)
        {
            _CourseTaskRepository = CourseTaskRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectNameFromCourseTaskBySchoolIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseTask> CourseTasks = _CourseTaskRepository.FilterWithInclude((x => x.IsActive && x.BaseSchoolNameId==request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId ), "BnaSubjectName");
            List<SelectedModel> selectModels = CourseTasks.Select(x => new SelectedModel 
            {
                Text = x.BnaSubjectName.SubjectName,
                Value = x.BnaSubjectNameId
            }).ToList();
            return selectModels;
        }
    }
}
