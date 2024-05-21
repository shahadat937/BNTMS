using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseTerm : BaseDomainEntity
    {

        public int CourseTermId { get; set; }
        public int CourseLevelId { get; set; }
        public string CourseTermTitle { get; set; }
        public int? BaseSchoolNameId { get; set; } 
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
 
    }
}
