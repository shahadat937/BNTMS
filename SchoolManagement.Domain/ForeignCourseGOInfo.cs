using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ForeignCourseGOInfo : BaseDomainEntity
    {
        

        public int ForeignCourseGOInfoId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public string? DocumentName { get; set; }
        public string? FileUpload { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseName? CourseName { get; set; }


    }
}
