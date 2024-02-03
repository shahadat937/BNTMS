using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DefenseType
{
    public interface IDefenseTypeDto
    {
        public int DefenseTypeId { get; set; }
        public string DefenseTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
