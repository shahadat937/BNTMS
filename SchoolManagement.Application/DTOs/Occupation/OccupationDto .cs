using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Occupation
{
    public class OccupationDto : IOccupationDto
    {
        public int OccupationId { get; set; }
        public string OccupationName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
