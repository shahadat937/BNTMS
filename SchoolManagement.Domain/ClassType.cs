using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ClassType : BaseDomainEntity
    {
        public ClassType()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
        }

        public int ClassTypeId { get; set; }
        public string? ClassTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
    }
}
