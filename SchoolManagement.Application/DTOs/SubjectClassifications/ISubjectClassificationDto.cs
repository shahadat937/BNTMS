namespace SchoolManagement.Application.DTOs.SubjectClassifications
{
    public interface ISubjectClassificationDto
    {
        public int SubjectClassificationId { get; set; }
        public string SubjectClassificationName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
