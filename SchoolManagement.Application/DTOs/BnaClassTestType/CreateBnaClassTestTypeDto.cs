namespace SchoolManagement.Application.DTOs.BnaClassTestType
{
    public class CreateBnaClassTestTypeDto : IBnaClassTestTypeDto
    {
        public int BnaClassTestTypeId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
