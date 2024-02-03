using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public partial class ReadingMaterialTitle:BaseDomainEntity
    {
        public ReadingMaterialTitle()
        {
            ReadingMaterials = new HashSet<ReadingMaterial>();
        }

        public int ReadingMaterialTitleId { get; set; }
        public string? Title { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
    }
}
