using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaServiceType
{
    public class BnaServiceTypeDto : IBnaServiceTypeDto
    {
        public int BnaServiceTypeId { get; set; }
        public string ServiceName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
