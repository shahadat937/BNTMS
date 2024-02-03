using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivityType
{
    public class CreateCoCurricularActivityTypeDto : ICoCurricularActivityTypeDto
    {
        public int CoCurricularActivityTypeId { get; set; }
        public string CoCurricularActivityName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
