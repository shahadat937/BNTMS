using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TdecActionStatus : BaseDomainEntity
    {
        public TdecActionStatus()
        {
            TdecGroupResults = new HashSet<TdecGroupResult>();
        }

        public int TdecActionStatusId { get; set; }
        public string? Name { get; set; }
        public double? Mark { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TdecGroupResult> TdecGroupResults { get; set; }
    }
}
