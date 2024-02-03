using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;

namespace SchoolManagement.Application.DTOs.ReadingMaterial
{
    public class CreateSoftCopyUploadDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateRoutineSoftCopyUploadDto RoutineSoftCopyUploadForm { get; set; }
}
}
  