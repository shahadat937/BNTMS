using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class MarkType : BaseDomainEntity
    {
        public MarkType()
        {
            SubjectMarks = new HashSet<SubjectMark>();
            CourseInstructors = new HashSet<CourseInstructor>();
        }

        public int MarkTypeId { get; set; }
        public string? TypeName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; } 
        public bool IsActive { get; set; }
        public int? PolicyStatus { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
    }
}
