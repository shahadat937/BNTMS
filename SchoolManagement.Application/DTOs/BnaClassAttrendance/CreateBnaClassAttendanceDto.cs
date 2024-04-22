using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.BnaClassAttrendance
{
    public class CreateBnaClassAttendanceDto : IBnaClassAttendanceDto
    {
        public int BnaClassAttendanceId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? ClassPeriodId { get; set; }
        public DateTime? Date { get; set; }
        public int? TraineeId { get; set; }
        public int? SubjectId { get; set; }
        public int? InstructorId { get; set; }
        public bool AttendanceStatus { get; set; }
        public string? Remark { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public List<StudentAttendanceForm> studentAttendanceForm  { get; set; }
}
    public class StudentAttendanceForm
    {
        public int? traineeId { get; set; }
        public int? subjectId { get; set; }
        public int? instructorId { get; set; }
        public bool attendance { get; set; }
        public string? remark { get; set; }
    }
}
