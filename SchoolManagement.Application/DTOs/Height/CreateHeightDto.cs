using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Height
{
    public class CreateHeightDto : IHeightDto
    {
        public int HeightId { get; set; }
        public string HeightName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
