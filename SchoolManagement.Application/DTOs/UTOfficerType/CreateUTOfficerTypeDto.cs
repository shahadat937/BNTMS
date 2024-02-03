using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerType
{
    public class CreateUtofficerTypeDto : IUtofficerTypeDto
    {
        public int UtofficerTypeId { get; set; }
        public string UtofficerTypeName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
