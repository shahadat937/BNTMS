using SchoolManagement.Domain.Common;


namespace SchoolManagement.Domain
{
    public class TraineeBioDataOther : BaseDomainEntity
    {
        public int TraineeBioDataOtherId { get; set; }
        public int? TraineeId { get; set; }
        public int? BnaCurriculumTypeId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? UtofficerTypeId { get; set; }
        public int? UtofficerCategoryId { get; set; }
        public int? BnaServiceTypeId { get; set; }
        public int? ComplexionId { get; set; }
        public int? BranchId { get; set; }
        public int? HeightId { get; set; }
        public int? WeightId { get; set; }
        public int? ColorOfEyeId { get; set; }
        public int? BloodGroupId { get; set; }
        public int? ReligionId { get; set; }
        public int? CasteId { get; set; }
        public int? CountryId { get; set; }
        public int? SnationalityId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? BnaPromotionStatusId { get; set; }
        public int? BnaClassSectionSelectionId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? FailureStatusId { get; set; }
        public int? BnaInstructorTypeId { get; set; }
        public int? PresentBilletId { get; set; }
        public string? Age { get; set; }
        public DateTime? CommissionDate { get; set; }
        public string? PostCode { get; set; }
        public string? IdentificationMark { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public int? TraineeStatus { get; set; }
        public string? PassportNo { get; set; }
        public string? DrivingLiccense { get; set; }
        public string? BankAccount { get; set; }
        public string? CreditCard { get; set; }
        public DateTime? DateOfMarriage { get; set; }
        public string? Remarks { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? DualNationality { get; set; }
        public string? ReasonOfMigration { get; set; }
        public DateTime? MigrationDate { get; set; }
        public string? AdditionalInformation { get; set; }
        public DateTime? RelegationDate { get; set; }
        public string? RelegationRemarks { get; set; }
        public string? RelegationDocument { get; set; }
        public string? ShortCode { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BloodGroup? BloodGroup { get; set; }
        public virtual BnaClassSectionSelection? BnaClassSectionSelection { get; set; }
        public virtual BnaCurriculumType? BnaCurriculumType { get; set; }
        public virtual BnaInstructorType? BnaInstructorType { get; set; }
        public virtual BnaPromotionStatus? BnaPromotionStatus { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual BnaServiceType? BnaServiceType { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual Caste? Caste { get; set; }
        public virtual ColorOfEye? ColorOfEye { get; set; }
        public virtual Complexion? Complexion { get; set; }
        public virtual Country? Country { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual FailureStatus? FailureStatus { get; set; }
        public virtual Height? Height { get; set; }
        public virtual MaritalStatus? MaritalStatus { get; set; }
        public virtual PresentBillet? PresentBillet { get; set; }
        public virtual Religion? Religion { get; set; }
        public virtual Nationality? Snationality { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual UtofficerCategory? UtofficerCategory { get; set; }
        public virtual UtofficerType? UtofficerType { get; set; }
        public virtual Weight? Weight { get; set; }
    }
}
