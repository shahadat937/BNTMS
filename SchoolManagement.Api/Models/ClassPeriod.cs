using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ClassPeriod
    {
        public ClassPeriod()
        {
            Attendances = new HashSet<Attendance>();
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            ClassRoutines = new HashSet<ClassRoutine>();
        }

        public int ClassPeriodId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BnaClassScheduleStatusId { get; set; }
        public string PeriodName { get; set; }
        public string DurationForm { get; set; }
        public string DurationTo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BnaClassScheduleStatus BnaClassScheduleStatus { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
    }
}
