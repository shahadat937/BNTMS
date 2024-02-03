using System;

namespace SchoolManagement.Application.DTOs.Attendance
{
    public class CreateAttendanceListDto : IAttendanceDto
    {
        public int AttendanceId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? ExamAttemptTypeId { get; set; } 
        public int? ExamTypeId { get; set; }
        public int? TraineeId { get; set; }
        public string? IndexNo { get; set; }
        public int? FamilyAllowId { get; set; }
        public int? TraineeCourseStatusId { get; set; }
        public int? Status { get; set; }
        public int? BnaAttendanceRemarksId { get; set; }
        public bool? AttendanceStatus { get; set; }
        public bool? AbsentForExamStatus { get; set; }
        public string? ClassLeaderName { get; set; }
        public DateTime? AttendanceDate { get; set; }
    }
}

