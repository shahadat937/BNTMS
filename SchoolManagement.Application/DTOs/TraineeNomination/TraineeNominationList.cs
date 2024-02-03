using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public class TraineeNominationList
    {
        public int CourseNomeneeId { get; set; }
        public int AttendanceId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseAttendState { get; set; }
        public int? CourseSectionId { get; set; }
        public string? CourseAttendStateRemark { get; set; }
        public string? ClassPeriodId { get; set; }
        public object? AttendanceDate { get; set; }
        public string? ClassLeaderName { get; set; } 
        public string? indexNo { get; set; }
        public bool? AttendanceStatus { get; set; }
        

        public List<TraineeListFormForNomination>? TraineeListForm { get; set; }
    }
}
