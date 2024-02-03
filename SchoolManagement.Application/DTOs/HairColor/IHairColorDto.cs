using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.HairColor
{
    public interface IHairColorDto
    {
        public int HairColorId { get; set; }
        public string HairColorName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
