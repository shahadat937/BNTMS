using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.ReadingMaterial
{
    public class CreateMaterialDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateReadingMaterialDto ReadingMaterialForm { get; set; }
}
}
