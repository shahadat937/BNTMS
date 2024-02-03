using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseModule : BaseDomainEntity
    {
        public CourseModule()
        {
            BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            CourseNomenees = new HashSet<CourseNomenee>();

            CourseInstructors = new HashSet<CourseInstructor>();
            ClassRoutines = new HashSet<ClassRoutine>();
            SubjectMarks = new HashSet<SubjectMark>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
        }

        public int CourseModuleId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public string? ModuleName { get; set; }
        public string? NameOfModule { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
    }
}
