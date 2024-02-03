using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AssignmentMarkEntry
    {
        public int AssignmentMarkEntryId { get; set; }
        public int? TraineeAssignmentSubmitId { get; set; }
        public int? InstructorAssignmentId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? TraineeId { get; set; }
        public double? AssignmentMark { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeAssignmentSubmit TraineeAssignmentSubmit { get; set; }
    }
}
