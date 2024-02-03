using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentMark
{
    public class TraineeAssessmentMarkDto : ITraineeAssessmentMarkDto
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

        public string? BaseSchoolName { get; set; }
        public string? CourseDuration { get; set; }
        public string? Trainee { get; set; }
        public string? TraineeAssessmentCreate { get; set; }
        public string? TraineeNomination { get; set; }

    }
}
