using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeAssissmentGroup
{
    public class TraineeAssissmentGroupDto : ITraineeAssissmentGroupDto
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

        public string? CourseName { get; set; }
        public string? CourseDuration { get; set; }
        public string? Trainee { get; set; }
        public string? TraineeRank { get; set; }
        public string? SailorRank { get; set; }
        public string? TraineeAssissmentCreate { get; set; }
        public string? TraineeNomination { get; set; }

    }
}
