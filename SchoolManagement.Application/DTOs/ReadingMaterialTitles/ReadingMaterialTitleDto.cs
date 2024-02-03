using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReadingMaterialTitles 
{
    public class ReadingMaterialTitleDto : IReadingMaterialTitleDto  
    {
        public int ReadingMaterialTitleId { get; set; }
        public string? Title { get; set; }
    }
}

