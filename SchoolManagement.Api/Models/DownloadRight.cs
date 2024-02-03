using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DownloadRight
    {
        public DownloadRight()
        {
            ReadingMaterials = new HashSet<ReadingMaterial>();
        }

        public int DownloadRightId { get; set; }
        public string DownloadRightName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
    }
}
