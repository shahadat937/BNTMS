using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ClassType
{

    
    public class CreateClassTypeDto : IClassTypeDto
    {
        public int ClassTypeId { get; set; }
        public string? ClassTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
