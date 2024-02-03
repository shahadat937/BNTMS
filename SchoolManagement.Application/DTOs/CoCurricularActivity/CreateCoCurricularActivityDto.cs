using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivity
{
    public class CreateCoCurricularActivityDto : ICoCurricularActivityDto
    {
        public int CoCurricularActivityId { get; set; }
        public int TraineeId { get; set; }
        public int CoCurricularActivityTypeId { get; set; }
        public string? Participation { get; set; }
        public string? Achievement { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
