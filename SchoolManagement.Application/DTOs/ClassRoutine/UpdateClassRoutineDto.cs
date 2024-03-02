using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.ClassRoutine
{
    public class UpdateClassRoutineDto
    {
        public int classRoutineId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? DepartmentId { get; set; }
        public int? courseModuleId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? courseTitleId { get; set; }
        public int? classPeriodId { get; set; }
        public int? baseSchoolNameId { get; set; }
        public int? courseDurationId { get; set; }
        public int? BranchId { get; set; }
        public string? subjectName { get; set; }
        public int? bnaSubjectNameId { get; set; }
        public int? courseWeekId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? AttendanceComplete { get; set; }
        public string? TimeDuration { get; set; }
        public int? examMarkComplete { get; set; }
        public int? classTypeId { get; set; }
        public int? classCountPeriod { get; set; }
        public int? subjectCountPeriod { get; set; }
        public DateTime? date { get; set; }
        public string? Remarks { get; set; }
        public string? classLocation { get; set; }
        public bool? isApproved { get; set; }
        public string? ClassRoomName { get; set; }
        public string? ClassTopic { get; set; }
        public DateTime? approvedDate { get; set; }
        public string? approvedBy { get; set; }
        public int? status { get; set; }
        public int? MenuPosition { get; set; }
        public bool isActive { get; set; }
    }

    public class UpdateClassRoutineDtoList
    {
        public List<UpdateClassRoutineDto> RoutineList { get; set; }
    }
}
