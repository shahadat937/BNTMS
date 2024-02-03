namespace SchoolManagement.Application.DTOs.ExamCenter
{
    public class ExamCenterDto: IExamCenterDto
    {
        public int ExamCenterId { get; set; }
        public string? ExamCenterName { get; set; }
        public bool IsActive { get; set; }
    }
}
