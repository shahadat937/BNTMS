using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetSubjectNameFromClassRoutineForLocalCourseRequestHandler : IRequestHandler<GetSubjectNameFromClassRoutineForLocalCourseRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSubjectNameFromClassRoutineForLocalCourseRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetSubjectNameFromClassRoutineForLocalCourseRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && (!x.Date.HasValue || x.Date.Value.Date == request.Date && x.ClassPeriodId == request.ClassPeriodId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId), "BnaSubjectName"); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                Text = x.BnaSubjectName.SubjectName,
                Value = x.BnaSubjectNameId 
            }).ToList();
            return selectModels;
        }
    }
}
