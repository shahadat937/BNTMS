using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class MemberShipType : BaseDomainEntity
    {
        public MemberShipType()
        {
            TraineeMemberships = new HashSet<TraineeMembership>();
        }

        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeMembership> TraineeMemberships { get; set; }
    }
}
