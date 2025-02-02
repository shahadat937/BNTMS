﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeAssissmentGroup
{
    public interface ITraineeAssissmentGroupDto
    {
        public int TraineeAssissmentGroupId { get; set; }
        public int? TraineeAssissmentCreateId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public string? AssissmentGroupName { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
