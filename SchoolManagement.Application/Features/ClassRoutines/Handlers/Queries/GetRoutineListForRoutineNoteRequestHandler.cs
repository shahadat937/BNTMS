using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetRoutineListForRoutineNoteRequestHandler : IRequestHandler<GetRoutineListForRoutineNoteRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetRoutineListForRoutineNoteRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetRoutineListForRoutineNoteRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId  && x.CourseDurationId == request.CourseDurationId && x.CourseWeekId == request.CourseWeekId && x.AttendanceComplete == 0, "BnaSubjectName", "ClassPeriod"); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                Text = x.Date + " ( "+x.BnaSubjectName.SubjectShortName + "-" + x.ClassPeriod.PeriodName +" )",
                Value = x.ClassRoutineId 
            }).ToList();
            return selectModels;
        }
    }
}
