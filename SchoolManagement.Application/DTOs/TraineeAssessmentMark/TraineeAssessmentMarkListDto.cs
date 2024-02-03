using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark.converter;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentMark
{ 
    public class TraineeAssessmentMarkListDto
    {
        public int TraineeAssessmentMarkId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? AssessmentTraineeId { get; set; }
        public int? TraineeAssessmentCreateId { get; set; }
        public int? AssessmentTypeId { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public List<AssessmentTraineeListFormDto>? assessmentTraineeListForm { get; set; }

    }
}
