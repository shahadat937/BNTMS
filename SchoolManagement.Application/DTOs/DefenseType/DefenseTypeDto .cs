using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DefenseType
{
    public class DefenseTypeDto : IDefenseTypeDto
    {
        public int DefenseTypeId { get; set; }
        public string DefenseTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
