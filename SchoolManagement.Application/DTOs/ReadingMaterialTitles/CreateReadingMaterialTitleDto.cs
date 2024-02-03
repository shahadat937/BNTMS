using SchoolManagement.Application.DTOs.CodeValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReadingMaterialTitles 
{
    public class CreateReadingMaterialTitleDto : IReadingMaterialTitleDto
    {
        public int ReadingMaterialTitleId { get; set; }
        public string? Title { get; set; }
    }
}
 