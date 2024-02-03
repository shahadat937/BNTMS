using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class InstructorAssignment
    {
        public InstructorAssignment()
        {
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
        }

        public int InstructorAssignmentId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? InstructorId { get; set; }
        public string AssignmentTopic { get; set; }
        public string Remarks { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? AssignmentMark { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseInstructor CourseInstructor { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
    }
}
