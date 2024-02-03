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
    public class GetSelectedSubjectNameByParametersFromClassRoutineRequestHandler : IRequestHandler<GetSelectedSubjectNameByParametersFromClassRoutineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedSubjectNameByParametersFromClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectNameByParametersFromClassRoutineRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId && x.AttendanceComplete ==1 && x.ExamMarkComplete == 0, "BnaSubjectName", "ClassPeriod", "CourseModule", "MarkType").Where(x=>x.ClassTypeId==4); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                Text = x.BnaSubjectName.SubjectName+"("+x.MarkType.ShortName+")_"+"Period -"+x.ClassPeriod.PeriodName, 
                Value = x.BnaSubjectNameId+"_"+x.CourseModuleId+"_"+ x.ClassRoutineId+"_"+x.CourseSectionId+"_"+x.SubjectMarkId+"_"+x.MarkTypeId
            }).ToList();
            return selectModels;
        }
    }
}
