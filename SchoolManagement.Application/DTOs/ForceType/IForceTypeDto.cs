using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForceType
{
    public interface IForceTypeDto
    {
        public int ForceTypeId { get; set; }
        public string ForceTypeName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
