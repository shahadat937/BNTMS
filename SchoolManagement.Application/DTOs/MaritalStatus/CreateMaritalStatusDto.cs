using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaritalStatus
{
    public class CreateMaritalStatusDto : IMaritalStatusDto
    {
        public int MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
