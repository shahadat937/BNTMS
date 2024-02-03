using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ClassType
{
    public interface IClassTypeDto
    {
        public int ClassTypeId { get; set; }
        public string? ClassTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
