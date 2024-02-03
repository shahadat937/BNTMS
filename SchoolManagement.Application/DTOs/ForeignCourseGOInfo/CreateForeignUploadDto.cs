using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.ForeignCourseGOInfo
{
    public class CreateForeignUploadDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateForeignCourseGOInfoDto ForeignCourseGOInfoForm { get; set; }
    }
}
