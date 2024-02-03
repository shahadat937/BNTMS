using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FailureStatus
{
    public interface IFailureStatusDto
    {
        public int FailureStatusId { get; set; }
        public string FailureStatusName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
