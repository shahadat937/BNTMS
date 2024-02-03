using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.SwimmingDrivingLevel
{
    public class SwimmingDrivingLevelDto : ISwimmingDrivingLevelDto
    {
        public int SwimmingDrivingLevelId { get; set; }
        public int SwimmingDrivingId { get; set; }
        public int LevelTypeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? LevelType { get; set; }
    }
}
