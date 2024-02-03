using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseType : BaseDomainEntity
    {
        public CourseType()
        {
            CourseDurations = new HashSet<CourseDuration>();
            CourseNames = new HashSet<CourseName>();
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
            Documents = new HashSet<Document>();
            InterServiceMarks = new HashSet<InterServiceMark>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();

        }

        public int CourseTypeId { get; set; }
        public string CourseTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<CourseName> CourseNames { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
    }
}
