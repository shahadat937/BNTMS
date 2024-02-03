using SchoolManagement.Domain.Common;


namespace SchoolManagement.Domain
{
    public class Occupation : BaseDomainEntity
    {
        public Occupation()
        {
            GrandFathers = new HashSet<GrandFather>();
            ParentRelativeOccupations = new HashSet<ParentRelative>();
            ParentRelativePreviousOccupations = new HashSet<ParentRelative>();
        }

        public int OccupationId { get; set; }
        public string OccupationName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GrandFather> GrandFathers { get; set; }
        public virtual ICollection<ParentRelative> ParentRelativeOccupations { get; set; }
        public virtual ICollection<ParentRelative> ParentRelativePreviousOccupations { get; set; }
    }
}
