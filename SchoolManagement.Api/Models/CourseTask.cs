using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CourseTask
    {
        public CourseTask()
        {
            TrainingObjectives = new HashSet<TrainingObjective>();
            TrainingSyllabi = new HashSet<TrainingSyllabus>();
        }

        public int CourseTaskId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string TaskDetail { get; set; }
        public string Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual ICollection<TrainingObjective> TrainingObjectives { get; set; }
        public virtual ICollection<TrainingSyllabus> TrainingSyllabi { get; set; }
    }
}
