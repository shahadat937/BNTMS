using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerCategory
{
    public class UtofficerCategoryDto : IUtofficerCategoryDto
    {
        public int UtofficerCategoryId { get; set; }
        public string UtofficerCategoryName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
