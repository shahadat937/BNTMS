using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivityType
{
    public interface ICoCurricularActivityTypeDto
    {

        public int CoCurricularActivityTypeId { get; set; }
        public string CoCurricularActivityName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
