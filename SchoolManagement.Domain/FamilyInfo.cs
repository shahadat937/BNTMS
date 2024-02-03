using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FamilyInfo : BaseDomainEntity
    {
        public FamilyInfo()
        {
            FamilyNominations = new HashSet<FamilyNomination>();
            
        }
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

        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual RelationType? RelationType { get; set; }
        public virtual Religion? Religion { get; set; }
        public virtual Caste? Caste { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual Division? Division { get; set; }
        public virtual District? District { get; set; }
        public virtual Thana? Thana { get; set; }
        public virtual Nationality? Nationality { get; set; }
        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }




    }
}
