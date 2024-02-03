using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaSubjectCurriculums
{
    public class BnaSubjectCurriculumDto : IBnaSubjectCurriculumDto
    {
        public int BnaSubjectCurriculumId { get; set; }
        public string SubjectCurriculumName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    } 
}
