using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingObjective
{
    public class TrainingObjectiveDto : ITrainingObjectiveDto
    {
        public int TrainingObjectiveId { get; set; }
        public int? CourseTaskId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string? TrainingObjectDetail { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? SchoolName { get; set; }
        public string? CourseName { get; set; }
        public string? SubjectName { get; set; }
        public string? CourseTask { get; set; }
    }
}
