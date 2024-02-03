using MediatR;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries   
{
    public class GetSelectedClassPeriodByParametersFromClassRoutineRequestHandler : IRequestHandler<GetSelectedClassPeriodByParametersFromClassRoutineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedClassPeriodByParametersFromClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedClassPeriodByParametersFromClassRoutineRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && (!x.Date.HasValue || x.Date.Value.Date == request.Date ), "ClassPeriod", "CourseSection").Where(x=>x.AttendanceComplete== CompleteStatus.NotCompleted); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                Text = x.ClassPeriod.PeriodName+"_"+ x.CourseSection.SectionName,
                Value = x.ClassRoutineId + "_" + x.ClassPeriodId+ "_" + x.CourseSectionId + "_" + x.BnaSubjectNameId
            }).Distinct().ToList();
            return selectModels;
        }
    }
}
