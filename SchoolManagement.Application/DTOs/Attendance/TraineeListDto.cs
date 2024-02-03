using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Attendance
{
    public class TraineeListDto
    {
        public int AttendanceId { get; set; }
        public int? CourseDurationId { get; set; }
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
        //public int? CourseDurationId { get; set; }
        //public int? CourseNameId { get; set; }
        //public int? TraineeId { get; set; }
        //public int? BnaAttendanceRemarksId { get; set; }
        //public bool? AttendanceStatus { get; set; }
    }
}
