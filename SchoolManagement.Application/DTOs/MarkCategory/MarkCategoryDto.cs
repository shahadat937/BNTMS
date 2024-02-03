namespace SchoolManagement.Application.DTOs.MarkCategory
{
    public class MarkCategoryDto : IMarkCategoryDto
    {
        public int MarkCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
