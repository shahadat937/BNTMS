using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class OrganizationName : BaseDomainEntity
    {
        public OrganizationName()
        {

            CourseDurations = new HashSet<CourseDuration>();
            InterServiceMarks = new HashSet<InterServiceMark>();
        }

        public int OrganizationNameId { get; set; }
        public int? ForceTypeId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ForceType? ForceType { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }

    }
}
