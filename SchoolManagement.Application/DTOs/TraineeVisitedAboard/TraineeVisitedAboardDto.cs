using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeVisitedAboard
{
    public class TraineeVisitedAboardDto : ITraineeVisitedAboardDto
    {
        public int TraineeVisitedAboardId { get; set; }
        public int TraineeId { get; set; }
        public int CountryId { get; set; }
        public string PurposeOfVisit { get; set; } = null!;
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? Country { get; set; }

    }
}
