using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaritalStatus
{
    public interface IMaritalStatusDto
    {
        public int MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
