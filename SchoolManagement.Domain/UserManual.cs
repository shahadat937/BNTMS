using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class UserManual : BaseDomainEntity
    {

        public int UserManualId { get; set; }
        public string? RoleName { get; set; }
        public string? Doc { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
