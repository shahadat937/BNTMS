namespace SchoolManagement.Application.DTOs.ExamCenter
{
    public class CreateExamCenterDto : IExamCenterDto 
    {
        public int ExamCenterId { get; set; }
        public string? ExamCenterName { get; set; }
        public bool IsActive { get; set; }
    }
}
 