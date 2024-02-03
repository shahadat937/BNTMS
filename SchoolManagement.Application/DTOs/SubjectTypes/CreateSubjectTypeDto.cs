using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectTypes
{
    public class CreateSubjectTypeDto : ISubjectTypeDto
    {
        public int SubjectTypeId { get; set; }
        public string? SubjectTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
