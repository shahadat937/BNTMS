using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Department : BaseDomainEntity
    {
        public Department()
        {
            CourseNomenees = new HashSet<CourseNomenee>();

            BnaSubjectNames = new HashSet<BnaSubjectName>();
            CourseInstructors = new HashSet<CourseInstructor>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

    }
}
