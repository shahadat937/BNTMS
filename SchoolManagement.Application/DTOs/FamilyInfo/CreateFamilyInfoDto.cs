namespace SchoolManagement.Application.DTOs.FamilyInfo
{
    public class CreateFamilyInfoDto : IFamilyInfoDto 
    {
        public int FamilyInfoId { get; set; }
        public int? TraineeId { get; set; }
        public int? RelationTypeId { get; set; }
        public int? ReligionId { get; set; }
        public int? CasteId { get; set; }
        public int? GenderId { get; set; }
        public int? DivisionId { get; set; }
        public int? DistrictId { get; set; }
        public int? ThanaId { get; set; }
        public int? NationalityId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? FullName { get; set; }
        public string? Nid { get; set; }
        public string? Passport { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 