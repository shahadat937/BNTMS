using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.DTOs.SwimmingDriving
{
    public class CreateSwimmingDrivingDto : ISwimmingDrivingDto
    {

        public int SwimmingDrivingId { get; set; }
        public int TraineeId { get; set; }
        public string AdditionalInformation { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public List<SelectedModelChecked> checkArray { get; set; }
    }
}
