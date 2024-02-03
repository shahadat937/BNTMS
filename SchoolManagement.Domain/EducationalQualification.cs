using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class EducationalQualification : BaseDomainEntity
    {
        public int EducationalQualificationId { get; set; }
        public int TraineeId { get; set; }
        public int ExamTypeId { get; set; }
        public int GroupId { get; set; }
        public int BoardId { get; set; }
        public string? Address { get; set; }
        public string? Subject { get; set; }
        public string? InstituteName { get; set; }
        public string? PassingYear { get; set; }
        public string Result { get; set; } = null!;
        public string? OutOfResult { get; set; }
        public string? CourseDuration { get; set; }
        public string? AdditionaInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateAttendedFrom { get; set; }
        public DateTime? DateAttendedTo { get; set; }

        public virtual Board Board { get; set; } = null!;
        public virtual ExamType ExamType { get; set; } = null!;
        public virtual Group Group { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;

    }
}
