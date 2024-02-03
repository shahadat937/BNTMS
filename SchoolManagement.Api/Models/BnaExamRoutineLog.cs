using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaExamRoutineLog
    {
        public int BnaExamRoutineLogId { get; set; }
        public DateTime? ExamDate { get; set; }
        public int? BnaExamScheduleId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? TraineeId { get; set; }
        public int? BnaClassSectionSelectionId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        public DateTime? DurationForm { get; set; }
        public DateTime? DurationTo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual BnaClassSectionSelection BnaClassSectionSelection { get; set; }
        public virtual BnaExamInstructorAssign BnaExamInstructorAssign { get; set; }
        public virtual BnaExamSchedule BnaExamSchedule { get; set; }
        public virtual BnaSemester BnaSemester { get; set; }
        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
