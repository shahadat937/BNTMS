using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ParentRelative : BaseDomainEntity
    {
        public int ParentRelativeId { get; set; }
        public int? TraineeId { get; set; }
        public int? RelationTypeId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? NationalityId { get; set; }
        public int? ReligionId { get; set; }
        public int? CasteId { get; set; }
        public int? OccupationId { get; set; }
        public int? PreviousOccupationId { get; set; }
        public int? GenderId { get; set; }
        public int? DivisionId { get; set; }
        public int? DistrictId { get; set; }
        public int? ThanaId { get; set; }
        public int? RankId { get; set; }
        public int? DefenseTypeId { get; set; }
        public int? SecondNationalityId { get; set; }
        public string? NameInFull { get; set; } 
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfMarriage { get; set; }
        public int? Age { get; set; }
        public int? DeadStatus { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public string? OccupationDetail { get; set; }
        public string? EducationQualification { get; set; }
        public string? MonthlyIncome { get; set; }
        public string? PostCode { get; set; }
        public string? PresentAddress { get; set; }
        public string? ParmanentAddress { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Remarks { get; set; }
        public string? IsDefenceJobExperience { get; set; }
        public DateTime? RetiredDate { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? DualNationality { get; set; }
        public string? ReasonOfMigration { get; set; }
        public DateTime? MigrationDate { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public virtual Caste? Caste { get; set; }

        
        public virtual CodeValue? DeadStatusNavigation { get; set; }

        public virtual DefenseType? DefenseType { get; set; }
        public virtual District? District { get; set; }
        public virtual Division? Division { get; set; }
        public virtual MaritalStatus? MaritalStatus { get; set; }
        public virtual Nationality? Nationality { get; set; }
        public virtual Occupation? Occupation { get; set; }
        public virtual Occupation? PreviousOccupation { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual Rank? Rank { get; set; }
        public virtual RelationType? RelationType { get; set; }
        public virtual Religion? Religion { get; set; }
        public virtual Nationality? SecondNationality { get; set; }
        public virtual Thana? Thana { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }

    }
}
