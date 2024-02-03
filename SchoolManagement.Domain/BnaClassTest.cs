using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaClassTest : BaseDomainEntity
    {
        public int BnaClassTestId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? SubjectCategoryId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? TraineeId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaClassTestTypeId { get; set; }
        public int? TotalMark { get; set; }
        public string? Percentage { get; set; }
        public string? ObtainedMark1 { get; set; }
        public string? ObtainedMark2 { get; set; }
        public string? ObtainedMark3 { get; set; }
        public string? ObtainedMark4 { get; set; }
        public string? ObtainedMark5 { get; set; }
        public int? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaClassTestType? BnaClassTestType { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual BnaSemesterDuration? BnaSemesterDuration { get; set; }
        public virtual BnaSubjectCurriculum? BnaSubjectCurriculum { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual SubjectCategory? SubjectCategory { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
