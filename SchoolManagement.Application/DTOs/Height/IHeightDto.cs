using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Height
{
    public interface IHeightDto
    {
        public int HeightId { get; set; }
        public string HeightName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
