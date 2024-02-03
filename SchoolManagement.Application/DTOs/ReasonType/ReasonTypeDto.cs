using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReasonType
{
    public class ReasonTypeDto : IReasonTypeDto
    {
        public int ReasonTypeId { get; set; }
        public string ReasonTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
