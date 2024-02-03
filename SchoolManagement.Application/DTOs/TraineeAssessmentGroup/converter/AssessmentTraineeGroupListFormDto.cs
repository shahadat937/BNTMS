using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeAssissmentGroup.converter
{ 
    public class AssessmentTraineeGroupListFormDto
    {

        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public bool? selectedStatus { get; set; }

    }
}
