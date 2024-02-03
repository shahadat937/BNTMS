using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForceType
{
    public class CreateForceTypeDto : IForceTypeDto
    {
        public int ForceTypeId { get; set; }
        public string ForceTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
