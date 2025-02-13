﻿using System;

namespace SchoolManagement.Application.DTOs.BnaClassSectionSelection
{
    public class CreateBnaClassSectionSelectionDto : IBnaClassSectionSelectionDto
    {
        public int BnaClassSectionSelectionId { get; set; }
        public string SectionName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
