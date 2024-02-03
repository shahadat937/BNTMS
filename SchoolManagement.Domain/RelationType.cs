using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class RelationType : BaseDomainEntity
    {
        public RelationType()
        {
            FamilyNominations = new HashSet<FamilyNomination>();
            ParentRelatives = new HashSet<ParentRelative>();
            MigrationDocuments = new HashSet<MigrationDocument>();
            FamilyInfos = new HashSet<FamilyInfo>();
        }

        public int RelationTypeId { get; set; }
        public string RelationTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }
        public virtual ICollection<MigrationDocument> MigrationDocuments { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }

    }
}
