using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReasonType
{
    public interface IReasonTypeDto
    {
        public int ReasonTypeId { get; set; }
        public string ReasonTypeName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
