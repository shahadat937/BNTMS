using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Assessment
{
    public class AssessmentDto : IAssessmentDto
    {
        public int AssessmentId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
