using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class UniversityCourseResult:BaseDomainEntity
    {
        public int UniversityCourseResultId { get; set; }

        public int? CourseDurationId { get; set; }
   
        public int TraineeId { get; set; } 

        public int? CourseNomeneeId { get; set; }

        public int? TraineeNominationId { get; set; }

        public int? CourseTermId { get; set; }

        public int? CourseLevelId { get; set; }

        public int? BaseSchoolNameId { get; set; }
        public double? TotalCredit { get; set; }
        public double? TotalMark { get; set; }
        public double? GPA { get; set; }
        public double? AchievedTotalCredit { get; set; }
        public double? AchievedTotalMark { get; set; }
        public double? AchievedGPA { get; set; }

        public string Remark { get; set; }

        public int? Status { get; set; }

        public int? MenuPosition { get; set; }

        public bool IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        //public virtual CourseInstructor? CourseInstructor { get; set; }
       // public virtual CourseName? CourseName { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; }
        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }

}
