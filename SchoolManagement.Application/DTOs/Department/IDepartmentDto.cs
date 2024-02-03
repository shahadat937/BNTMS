using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Department
{
    public interface IDepartmentDto
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
