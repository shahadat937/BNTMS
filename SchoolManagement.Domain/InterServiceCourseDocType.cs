using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class InterServiceCourseDocType : BaseDomainEntity
    {
        public InterServiceCourseDocType()
        {
            Documents = new HashSet<Document>();
        }

        public int InterServiceCourseDocTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
