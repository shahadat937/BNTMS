using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class GrandFatherType : BaseDomainEntity
    {
        public GrandFatherType()
        {
            GrandFathers = new HashSet<GrandFather>();
        }

        public int GrandfatherTypeId { get; set; }
        public string GrandfatherTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GrandFather> GrandFathers { get; set; }
    }
}
