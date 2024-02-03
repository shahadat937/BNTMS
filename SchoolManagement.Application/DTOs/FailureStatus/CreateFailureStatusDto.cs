using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.FailureStatus
{
    public class CreateFailureStatusDto : IFailureStatusDto
    {
        public int FailureStatusId { get; set; }
        public string FailureStatusName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
