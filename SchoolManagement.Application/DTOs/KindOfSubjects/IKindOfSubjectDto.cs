using System;

namespace SchoolManagement.Application.DTOs.KindOfSubjects 
{
    public interface IKindOfSubjectDto
    {
        public int KindOfSubjectId { get; set; }
        public string? KindOfSubjectName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
