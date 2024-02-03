using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.GrandFatherType
{
    public class GrandFatherTypeDto : IGrandFatherTypeDto
    {
        public int GrandfatherTypeId { get; set; }
        public string GrandfatherTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
