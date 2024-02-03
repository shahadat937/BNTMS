using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentCreate
{
    public class TraineeAssessmentCreateDto : ITraineeAssessmentCreateDto
    {

        public int TraineeAssessmentCreateId { get; set; }
        public string? AssessmentName { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? BaseSchoolName { get; set; }
        public string? CourseDuration { get; set; }
        public string? CourseName { get; set; }

    }
}
