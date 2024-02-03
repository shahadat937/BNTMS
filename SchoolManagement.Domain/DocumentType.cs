using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class DocumentType: BaseDomainEntity 
    {
        public DocumentType()
        {
            ReadingMaterials = new HashSet<ReadingMaterial>();
        }

        public int DocumentTypeId { get; set; }
        public string? DocumentTypeName { get; set; }
        public string? IconName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
    }
}
