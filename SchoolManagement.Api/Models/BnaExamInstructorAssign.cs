using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaExamInstructorAssign
    {
        public BnaExamInstructorAssign()
        {
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
        }

        public int BnaExamInstructorAssignId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? BnaInstructorTypeId { get; set; }
        public int? TraineeId { get; set; }
        public string ExamLocation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BnaInstructorType BnaInstructorType { get; set; }
        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual ClassRoutine ClassRoutine { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseModule CourseModule { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
    }
}
