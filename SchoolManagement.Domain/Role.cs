using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Role : BaseDomainEntity 
    {

        public string RoleId { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string LoweredRoleName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

    }
}
