using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaSubjectCurriculum : BaseDomainEntity
    {
        public BnaSubjectCurriculum()
        {
            CourseNomenees = new HashSet<CourseNomenee>();

            BnaClassTests = new HashSet<BnaClassTest>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            CourseInstructors = new HashSet<CourseInstructor>();
            SubjectMarks = new HashSet<SubjectMark>();
        }

        public int BnaSubjectCurriculumId { get; set; }
        public string SubjectCurriculumName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

    }
}
