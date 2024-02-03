using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Elected:BaseDomainEntity
    {
        public Elected()
        {
            Elections = new HashSet<Election>();
        }

        public int ElectedId { get; set; }
        public string ElectedType { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Election> Elections { get; set; }
    }
}
