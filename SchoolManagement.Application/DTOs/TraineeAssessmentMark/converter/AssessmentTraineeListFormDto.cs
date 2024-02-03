using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentMark.converter
{ 
    public class AssessmentTraineeListFormDto
    {
        
        public int? TraineeNominationId { get; set; }
        //public int? traineeAssissmentCreateId { get; set; }
        public int? TraineeId { get; set; }
        public string? Position { get; set; }
        public string? Knowledge { get; set; }
        public string? StaffDuty { get; set; }
        public string? Leadeship { get; set; }
        public string? Remarks { get; set; }        

    }
}
