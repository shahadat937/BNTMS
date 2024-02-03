using MediatR;
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
    public class GetApproveSubjectNameByParametersFromClassRoutineRequestHandler : IRequestHandler<GetApproveSubjectNameByParametersFromClassRoutineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetApproveSubjectNameByParametersFromClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetApproveSubjectNameByParametersFromClassRoutineRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId, "BnaSubjectName", "ClassPeriod", "CourseModule").Where(x=>x.ClassTypeId==4); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                Text = x.BnaSubjectName.SubjectName+"_"+x.CourseModule.ModuleName+"_ Period -"+x.ClassPeriod.PeriodName, 
                Value = x.BnaSubjectNameId+"_"+x.CourseModuleId
            }).ToList();
            return selectModels;
        }
    }
}
