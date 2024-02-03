using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SubjectMark : BaseDomainEntity
    {
        public SubjectMark()
        {
            BnaExamMarks = new HashSet<BnaExamMark>();
        }
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

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual BnaSubjectCurriculum? BnaSubjectCurriculum { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual SaylorBranch? SaylorBranch { get; set; }
        public virtual SaylorSubBranch? SaylorSubBranch { get; set; }
        public virtual CourseModule? CourseModule { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual MarkType? MarkType { get; set; }
        public virtual MarkCategory? MarkCategory { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
    }
}
