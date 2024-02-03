using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Languages
{
    public interface ILanguageDto 
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 