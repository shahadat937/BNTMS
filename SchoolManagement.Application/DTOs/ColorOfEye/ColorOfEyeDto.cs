using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ColorOfEye
{
    public class ColorOfEyeDto : IColorOfEyeDto
    {
        public int ColorOfEyeId { get; set; }
        public string ColorOfEyeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
