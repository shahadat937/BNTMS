using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineeStatus : BaseDomainEntity
    {
        public TraineeStatus()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
        }

        public int TraineeStatusId { get; set; }
        public string? Name { get; set; } 
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
    }
}
