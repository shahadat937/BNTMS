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
    public class GetSelectedSubjectNameByParametersFromAttendanceTableForExamRequestHandler : IRequestHandler<GetSelectedSubjectNameByParametersFromAttendanceTableForExamRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;
        private readonly ISchoolManagementRepository<Attendance> _AttendanceRepository;

        public GetSelectedSubjectNameByParametersFromAttendanceTableForExamRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository, ISchoolManagementRepository<Attendance> AttendanceRepository)
        {
            _classRoutineRepository = classRoutineRepository;
            _AttendanceRepository = AttendanceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectNameByParametersFromAttendanceTableForExamRequest request, CancellationToken cancellationToken)
        {
            var ReternModels = new List<SelectedModel>();
            var Attendances = _AttendanceRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId && x.AbsentForExamStatus == request.ExamStatus).ToList();
            List<Attendance> attendanceList = Attendances.AsEnumerable()
                          .Select(o => new Attendance
                          {
                              ClassRoutineId = o.ClassRoutineId
                          }).ToList();

            var routineList = attendanceList.GroupBy(x => x.ClassRoutineId).Select(g => g.FirstOrDefault().ClassRoutineId.ToString()).ToList();


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
