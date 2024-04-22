using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain
{
    public class BnaClassAttendance : BaseDomainEntity
    {
        public int BnaClassAttendanceId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? ClassPeriodId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public int? TraineeId { get; set; }
        public int? SubjectId { get; set; }
        public int? InstructorId { get; set; }
        public bool AttendanceStatus { get; set; }
        public string? Remark { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
