using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.SubjectClassifications
{
    public class SubjectClassificationDto : ISubjectClassificationDto
    {
        public int SubjectClassificationId { get; set; }
        public string SubjectClassificationName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
