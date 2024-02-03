namespace SchoolManagement.Application.DTOs.FamilyInfo
{
    public class FamilyInfoDto: IFamilyInfoDto
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

        
        public string? TraineeName { get; set; }
        public string? TraineePNo { get; set; }
        public string? RankPosition { get; set; }
        public string? RelationType { get; set; }
        public string? Religion { get; set; }
        public string? Caste { get; set; }
        public string? Gender { get; set; }
        public string? Division { get; set; }
        public string? District { get; set; }
        public string? Thana { get; set; }
        public string? Nationality { get; set; }


    }
}
