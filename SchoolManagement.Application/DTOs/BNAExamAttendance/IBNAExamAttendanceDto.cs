using System;

namespace SchoolManagement.Application.DTOs.BnaExamAttendance
{
    public interface IBnaExamAttendanceDto
    {
        public int BnaExamAttendanceId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaAttendanceRemarksId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? BnaExamScheduleId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? CourseNameId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? TraineeId { get; set; }
        public int? ExamTypeId { get; set; }
        public string? ClassLeaderName { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? AttendanceStatus { get; set; }
        public DateTime? ExamDate { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedUser { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
