using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentMark
{
    public interface ITraineeAssessmentMarkDto
    {
        public int TraineeAssessmentMarkId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? AssessmentTraineeId { get; set; }
        public int? TraineeId { get; set; }
        public int? TraineeAssessmentCreateId { get; set; }
        public int? AssessmentTypeId { get; set; }
        public string? Position { get; set; }
        public string? Knowledge { get; set; }
        public string? StaffDuty { get; set; }
        public string? Leadeship { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
