using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.ClassRoutine
{
    public class ClassRoutineDto : IClassRoutineDto
    {
        public int ClassRoutineId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? ClassCountPeriod { get; set; }
        public int? SubjectCountPeriod { get; set; }
        public int? CourseTitleId { get; set; }
        public int? BranchId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? CourseWeekId { get; set; }
        public int? AttendanceComplete { get; set; }
        public int? ResultSubmissionStatus { get; set; }
        public int? FinalApproveStatus { get; set; }
        public string? ClassLocation { get; set; }
        public string? TimeDuration { get; set; }
        public string? Remarks { get; set; }
        public string? ClassRoomName { get; set; }
        public string? ClassTopic { get; set; }


        public DateTime? Date { get; set; }
        public int? ClassTypeId { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public string? BaseSchoolName { get; set; }
        public string? BnaSubjectName { get; set; }
        public string? ClassPeriod { get; set; }
        public string? ClassPeriodDurationForm { get; set; }
        public string? ClassPeriodDurationTo { get; set; }
        public string? ClassType { get; set; }
        public string? CourseDuration { get; set; }
        public string? CourseModule { get; set; }
        public string? CourseName { get; set; }
        public string? CourseWeek { get; set; }
        public string? MarkType { get; set; }
        public string? Branch { get; set; }
        public string? CourseSection { get; set; }
        public string? Trainee { get; set; }

    }
}
