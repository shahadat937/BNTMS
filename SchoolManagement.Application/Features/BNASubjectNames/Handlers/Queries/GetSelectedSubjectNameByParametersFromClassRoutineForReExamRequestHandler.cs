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
    public class GetSelectedSubjectNameByParametersFromClassRoutineForReExamRequestHandler : IRequestHandler<GetSelectedSubjectNameByParametersFromClassRoutineForReExamRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;
        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

        public GetSelectedSubjectNameByParametersFromClassRoutineForReExamRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository, ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository)
        {
            _classRoutineRepository = classRoutineRepository;
            _BnaExamMarkRepository = BnaExamMarkRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectNameByParametersFromClassRoutineForReExamRequest request, CancellationToken cancellationToken)
        {
            var ReternModels = new List<SelectedModel>();
            var BnaExamMarks = _BnaExamMarkRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId && x.ObtaintMark < x.SubjectMark.PassMark).ToList();
            List<BnaExamMark> xmMarkList = BnaExamMarks.AsEnumerable()
                          .Select(o => new BnaExamMark
                          {
                              ClassRoutineId = o.ClassRoutineId
                          }).ToList();

            var routineList = xmMarkList.GroupBy(x => x.ClassRoutineId).Select(g => g.FirstOrDefault().ClassRoutineId.ToString()).ToList();


            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId && x.ClassTypeId == 4 && x.AttendanceComplete ==1 && routineList.Contains(x.ClassRoutineId.ToString()), "BnaSubjectName", "ClassPeriod", "CourseModule", "MarkType");
            ReternModels = new List<SelectedModel>();
            ReternModels = classRoutines.Select(x => new SelectedModel
            {
                Text = x.BnaSubjectName.SubjectName+"("+x.MarkType.ShortName+")_"+x.CourseModule.ModuleName+"_ Period -"+x.ClassPeriod.PeriodName, 
                Value = x.BnaSubjectNameId+"_"+x.CourseModuleId+"_"+ x.ClassRoutineId+"_"+x.CourseSectionId+"_"+x.SubjectMarkId+"_"+x.MarkTypeId
            }).ToList();
            return ReternModels;
        }
    }
}
