using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GrandFatherType
{
    public interface IGrandFatherTypeDto
    {

        public int GrandfatherTypeId { get; set; }
        public string GrandfatherTypeName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
