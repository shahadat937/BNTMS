using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Attendance.ApprovedAttendance
{
    public class AttendanceListFormDto
    {
        public int? AttendanceId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? CourseDurationId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? AttendanceStatus { get; set; }
        public bool? AbsentForExamStatus { get; set; }
        public int? BnaAttendanceRemarksId { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineePNo { get; set; }
        public string? TraineeName { get; set; } 
        public string? ClassLeaderName { get; set; }
        public string? RankPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
