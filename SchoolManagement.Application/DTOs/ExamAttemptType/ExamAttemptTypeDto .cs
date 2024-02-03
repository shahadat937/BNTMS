namespace SchoolManagement.Application.DTOs.ExamAttemptType
{
    public class ExamAttemptTypeDto: IExamAttemptTypeDto
    {
        public int ExamAttemptTypeId { get; set; }
        public string? ExamAttemptTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
