using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup.converter;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeAssissmentGroup
{ 
    public class TraineeAssessmentGroupListDto
    {
        public int TraineeAssissmentGroupId { get; set; }
        public int? TraineeAssissmentCreateId { get; set; }
        public int? CourseDurationId { get; set; }        
        public string? AssissmentGroupName { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public List<AssessmentTraineeGroupListFormDto>? assessmentTraineeGroupListForm { get; set; }

    }
}
