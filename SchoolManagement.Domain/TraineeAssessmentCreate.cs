using SchoolManagement.Domain.Common;


namespace SchoolManagement.Domain
{
    public class TraineeAssessmentCreate : BaseDomainEntity
    {
        public TraineeAssessmentCreate()
        {
            TraineeAssissmentGroups = new HashSet<TraineeAssissmentGroup>();
        }
        public int TraineeAssessmentCreateId { get; set; }
        public string? AssessmentName { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual ICollection<TraineeAssissmentGroup> TraineeAssissmentGroups { get; set; }
    }
}
