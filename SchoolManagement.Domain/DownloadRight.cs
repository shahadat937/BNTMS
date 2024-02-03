using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class DownloadRight : BaseDomainEntity
    {
        public DownloadRight()
        {
            ReadingMaterials = new HashSet<ReadingMaterial>();
        }

        public int DownloadRightId { get; set; }
        public string? DownloadRightName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
    }
}
