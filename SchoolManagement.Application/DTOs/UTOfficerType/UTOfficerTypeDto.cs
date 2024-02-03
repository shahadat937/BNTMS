using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerType
{
    public class UtofficerTypeDto : IUtofficerTypeDto
    {
        public int UtofficerTypeId { get; set; }
        public string UtofficerTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
