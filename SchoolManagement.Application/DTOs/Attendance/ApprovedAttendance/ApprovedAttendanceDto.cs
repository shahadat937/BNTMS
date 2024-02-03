using System;

namespace SchoolManagement.Application.DTOs.Attendance.ApprovedAttendance
{ 
    public class ApprovedAttendanceDto : IAttendanceDto
    { 
        public int? AttendanceId { get; set; } 
        public string? BaseSchoolNameId { get; set; } 
        public string? CourseNameId { get; set; }
        public string? ClassPeriodId { get; set; }
        public int? CourseSectionId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public int? Status { get; set; }
        public List<AttendanceListFormDto>? TraineeListForm { get; set; }
    }
}
