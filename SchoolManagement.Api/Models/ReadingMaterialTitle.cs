using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ReadingMaterialTitle
    {
        public ReadingMaterialTitle()
        {
            ReadingMaterials = new HashSet<ReadingMaterial>();
        }

        public int ReadingMaterialTitleId { get; set; }
        public string Title { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
    }
}
