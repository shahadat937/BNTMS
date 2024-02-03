namespace SchoolManagement.Application.DTOs.Department
{
    public class DepartmentDto : IDepartmentDto
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
