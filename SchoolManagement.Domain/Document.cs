using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Document : BaseDomainEntity
    {
        public int DocumentId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? InterServiceCourseDocTypeId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentUpload { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual CourseType? CourseType { get; set; }
        public virtual InterServiceCourseDocType? InterServiceCourseDocType { get; set; }
    }
    
}
