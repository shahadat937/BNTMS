using System;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.DTOs.Religion;

namespace SchoolManagement.Application.DTOs.TraineeBioDataOther
{
    public class TraineeBioDataOtherDto : ITraineeBioDataOtherDto
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

        public string? BloodGroup { get; set; }
        public string? BnaClassSectionSelection { get; set; }
        public string? BnaCurriculumType { get; set; }
        public string? BnaInstructorType { get; set; }
        public string? BnaPromotionStatus { get; set; }
        public string? BnaSemester { get; set; }
        public string? BnaServiceType { get; set; }
        public string? Branch { get; set; }
        public string? Caste { get; set; }
        public string? ColorOfEye { get; set; }
        public string? Complexion { get; set; }
        public string? CourseName { get; set; }
        public string? Country { get; set; }
        public string? FailureStatus { get; set; }
        public string? Height { get; set; }
        public string? MaritalStatus { get; set; }
        public string? PresentBillet { get; set; }
        public string? Religion { get; set; }
        // public string  TraineeBIODataGeneralInfo { get; set; }
        public string? UtofficerCategory { get; set; }
        public string? UtofficerType { get; set; }
        public string? Weight { get; set; }

    }
}
