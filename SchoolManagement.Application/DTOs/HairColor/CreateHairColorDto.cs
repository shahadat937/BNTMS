using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.HairColor
{
    public class CreateHairColorDto : IHairColorDto
    {
        public int HairColorId { get; set; }
        public string HairColorName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
