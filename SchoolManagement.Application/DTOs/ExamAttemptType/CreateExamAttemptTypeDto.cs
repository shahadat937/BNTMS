namespace SchoolManagement.Application.DTOs.ExamAttemptType
{
    public class CreateExamAttemptTypeDto : IExamAttemptTypeDto 
    {
        public int ExamAttemptTypeId { get; set; }
        public string? ExamAttemptTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
 