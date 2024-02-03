using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{ 
    public class ReadingMaterial : BaseDomainEntity
    {
        public int ReadingMaterialId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ShowRightId { get; set; }
        public int? DownloadRightId { get; set; }
        public int? ReadingMaterialTitleId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? ApprovedUser { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
        public string? AurhorName { get; set; }
        public string? PublisherName { get; set; }

        public virtual ReadingMaterialTitle? ReadingMaterialTitle { get; set; }
        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual DocumentType? DocumentType { get; set; }
        public virtual DownloadRight? DownloadRight { get; set; }
        public virtual BaseSchoolName? ShowRight { get; set; }
    }
}
