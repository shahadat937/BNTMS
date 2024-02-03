using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaClassTestType
{
    public class BnaClassTestTypeDto : IBnaClassTestTypeDto
    {
        public int BnaClassTestTypeId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
