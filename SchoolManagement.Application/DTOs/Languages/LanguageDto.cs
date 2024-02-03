using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Languages
{
    public class LanguageDto : ILanguageDto
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}

