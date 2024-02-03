using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SwimmingDriving
{
    public interface ISwimmingDrivingDto
    {

        public int SwimmingDrivingId { get; set; }
        public int TraineeId { get; set; }
        public string AdditionalInformation { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
