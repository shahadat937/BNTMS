using System;

namespace SchoolManagement.Application.DTOs.BnaClassSectionSelection
{  
    public interface IBnaClassSectionSelectionDto
    {
        public int BnaClassSectionSelectionId { get; set; }
        public string? SectionName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
