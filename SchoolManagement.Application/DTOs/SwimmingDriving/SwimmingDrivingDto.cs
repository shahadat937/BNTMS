using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.SwimmingDriving
{
    public class SwimmingDrivingDto : ISwimmingDrivingDto
    {

        public int SwimmingDrivingId { get; set; }
        public int TraineeId { get; set; }
        public string AdditionalInformation { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
