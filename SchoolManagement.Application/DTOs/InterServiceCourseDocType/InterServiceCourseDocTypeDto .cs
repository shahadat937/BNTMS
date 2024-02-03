using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InterServiceCourseDocType
{
    public class InterServiceCourseDocTypeDto : IInterServiceCourseDocTypeDto
    {
        public int InterServiceCourseDocTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
