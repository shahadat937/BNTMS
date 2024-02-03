namespace SchoolManagement.Application.DTOs.BnaCurriculamType
{
    public class BnaCurriculamTypeDto: IBnaCurriculamTypeDto
    {
        public int BnaCurriculumTypeId { get; set; }
        public string CurriculumType { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
