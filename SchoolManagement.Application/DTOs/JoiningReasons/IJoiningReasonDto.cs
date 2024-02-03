using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.JoiningReasons
{
    public interface IJoiningReasonDto
    {
        public int JoiningReasonId { get; set; }
        public int TraineeId { get; set; }
        public int ReasonTypeId { get; set; }
        public string? IfAnotherReason { get; set; }
        public string? AdditionlInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 