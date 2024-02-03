using System;

namespace SchoolManagement.Application.DTOs.SubjectClassifications
{
    public class CreateSubjectClassificationDto : ISubjectClassificationDto
    {
        public int SubjectClassificationId { get; set; }
        public string SubjectClassificationName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
