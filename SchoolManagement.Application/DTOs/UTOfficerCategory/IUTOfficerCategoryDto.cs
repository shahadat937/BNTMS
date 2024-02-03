using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerCategory
{
    public interface IUtofficerCategoryDto
    {
        public int UtofficerCategoryId { get; set; }
        public string UtofficerCategoryName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
