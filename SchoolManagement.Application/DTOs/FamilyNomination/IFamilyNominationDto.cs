namespace SchoolManagement.Application.DTOs.FamilyNomination
{
    public interface IFamilyNominationDto
    {
        public int FamilyNominationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeId { get; set; }
        public int? FamilyInfoId { get; set; }
        public int? FundingDetailId { get; set; }
        public int? RelationTypeId { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 