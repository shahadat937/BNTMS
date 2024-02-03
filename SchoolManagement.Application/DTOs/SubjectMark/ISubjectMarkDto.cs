namespace SchoolManagement.Application.DTOs.SubjectMark
{
    public interface ISubjectMarkDto 
    {
        public int SubjectMarkId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BranchId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? MarkCategoryId { get; set; }
        public int? MarkTypeId { get; set; }
        public double? PassMark { get; set; }
        public double? Mark { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
