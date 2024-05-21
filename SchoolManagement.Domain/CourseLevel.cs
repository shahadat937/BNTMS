using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseLevel : BaseDomainEntity
    {
   
        public int CourseLevelId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? CourseLeveTitle { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


    }
}
