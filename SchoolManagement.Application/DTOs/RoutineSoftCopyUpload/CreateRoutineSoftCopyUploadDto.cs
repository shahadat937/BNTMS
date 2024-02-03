using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.RoutineSoftCopyUpload
{
    public class CreateRoutineSoftCopyUploadDto : IRoutineSoftCopyUploadDto
    {
        public int RoutineSoftCopyUploadId { get; set; }
        public int CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? DocumentLink { get; set; }
        public string? DocumentName { get; set; }

        public int? Status { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsActive { get; set; }

        public IFormFile? Doc { get; set; }
    }
}
