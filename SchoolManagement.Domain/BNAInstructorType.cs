using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaInstructorType : BaseDomainEntity
    {
        public BnaInstructorType()
        {
            BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int BnaInstructorTypeId { get; set; }
        public string InstructorTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
