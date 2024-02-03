using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CoursePlanCreate: BaseDomainEntity
    {
        public int CoursePlanCreateId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? CoursePlanName { get; set; }
        public string? Value { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseName? CourseName { get; set; }
    }
}
