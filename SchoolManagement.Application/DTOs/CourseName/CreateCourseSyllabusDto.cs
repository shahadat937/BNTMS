using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.CourseName
{
    public class CreateCourseSyllabusDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateCourseNameDto CourseNameForm { get; set; }
    }
}
