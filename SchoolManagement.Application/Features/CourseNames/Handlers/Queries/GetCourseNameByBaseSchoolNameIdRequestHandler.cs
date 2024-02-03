using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Queries 
{
    public class GetCourseNameByBaseSchoolNameIdRequestHandler : IRequestHandler<GetCourseNameByBaseSchoolNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        public GetCourseNameByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetCourseNameByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> codeValues = _ClassRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId, "CourseName", "CourseDuration");

            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course + "_" + x.CourseDuration.CourseTitle,
                Value = x.CourseDurationId + "_" + x.CourseNameId
            }).Distinct().ToList();
            return selectModels;

            //IQueryable<CourseDuration> codeValues = _CourseDurationRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.IsCompletedStatus == 0, "CourseName");
            //List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            //{
            //    Text = x.CourseName.Course + "_" + x.CourseTitle,
            //    Value = x.CourseDurationId + "_" + x.CourseNameId
            //}).ToList();
            //return selectModels;
        }
    }
}
