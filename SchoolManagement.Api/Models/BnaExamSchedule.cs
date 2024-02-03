using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaExamSchedule
    {
        public BnaExamSchedule()
        {
            Attendances = new HashSet<Attendance>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            ExamCenterSelections = new HashSet<ExamCenterSelection>();
        }

        public int BnaExamScheduleId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? ExamTypeId { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? DurationTo { get; set; }
        public string ExamLocation { get; set; }
        public int? ExamSheduleStatus { get; set; }
        public int? IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? IsApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaSemester BnaSemester { get; set; }
        public virtual BnaSemesterDuration BnaSemesterDuration { get; set; }
        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual ExamType ExamType { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<ExamCenterSelection> ExamCenterSelections { get; set; }
    }
}
