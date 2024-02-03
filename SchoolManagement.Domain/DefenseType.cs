using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class DefenseType : BaseDomainEntity
    {
        public DefenseType()
        {
            ParentRelatives = new HashSet<ParentRelative>();
        }

        public int DefenseTypeId { get; set; }
        public string DefenseTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
    }
}
