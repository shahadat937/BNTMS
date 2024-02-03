using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class NewEntryEvaluation : BaseDomainEntity
    {
        public int NewEntryEvaluationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseWeekId { get; set; }
        public int? TraineeId { get; set; }
        public int? TraineeNominationId { get; set; }
        public double? Noitikota { get; set; }
        public double? Sahonsheelota { get; set; }
        public double? Utsaho { get; set; }
        public double? Samayanubartita { get; set; }
        public double? Manovhab { get; set; }
        public double? Udyam { get; set; }
        public double? KhapKhawano { get; set; }
        public double? Onyano { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual CourseModule? CourseModule { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseWeek? CourseWeek { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }




    }
}
