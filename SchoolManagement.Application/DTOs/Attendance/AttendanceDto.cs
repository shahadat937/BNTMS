using System;

namespace SchoolManagement.Application.DTOs.Attendance
{
    public class AttendanceDto : IAttendanceDto
    {
        public int AttendanceId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaAttendanceRemarksId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? CourseSectionId { get; set; }
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
        public bool? AbsentForExamStatus { get; set; }
        public DateTime? ExamDate { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedUser { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
        public string? ClassRoutine { get; set; }
        public string? CourseName { get; set; }
        public string? ClassPeriod { get; set; } 
        public string? BnaSubjectName { get; set; }
        public string? BnaAttendanceRemarks { get; set; }
        public string? BaseSchoolName { get; set; }
        public string? TraineeName { get; set; }
        public string? RankName { get; set; }
        public string? TraineePNo { get; set; }
        public string? RankPosition { get; set; }
    }
}
