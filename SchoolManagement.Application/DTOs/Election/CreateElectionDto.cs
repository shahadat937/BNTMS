using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Election
{
    public class CreateElectionDto : IElectionDto
    {
        public int ElectionId { get; set; }
        public int TraineeId { get; set; }
        public int ElectedId { get; set; }
        public string? InstituteName { get; set; }
        public string? AppointmentName { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? DurationTo { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
