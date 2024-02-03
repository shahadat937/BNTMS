namespace SchoolManagement.Application.DTOs.ForeignCourseDocType
{
    public class CreateForeignCourseDocTypeDto : IForeignCourseDocTypeDto
    {
        public int ForeignCourseDocTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
