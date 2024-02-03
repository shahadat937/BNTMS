using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SwimmingDrivingLevel
{
    public interface ISwimmingDrivingLevelDto
    {
        public int SwimmingDrivingLevelId { get; set; }
        public int SwimmingDrivingId { get; set; }
        public int LevelTypeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
