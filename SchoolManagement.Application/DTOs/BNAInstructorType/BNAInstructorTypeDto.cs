using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaInstructorType
{
    public class BnaInstructorTypeDto : IBnaInstructorTypeDto
    {
        public int BnaInstructorTypeId { get; set; }
        public string InstructorTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
