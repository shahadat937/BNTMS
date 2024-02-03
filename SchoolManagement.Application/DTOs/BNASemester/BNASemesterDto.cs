namespace SchoolManagement.Application.DTOs.BnaSemester
{
    public class BnaSemesterDto : IBnaSemesterDto
    {
        public int BnaSemesterId { get; set; }
        public string SemesterName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
