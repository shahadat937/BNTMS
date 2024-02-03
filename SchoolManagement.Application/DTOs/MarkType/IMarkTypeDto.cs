namespace SchoolManagement.Application.DTOs.MarkType
{
    public interface IMarkTypeDto
    {
        public int MarkTypeId { get; set; }
        public string? TypeName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public int? PolicyStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
