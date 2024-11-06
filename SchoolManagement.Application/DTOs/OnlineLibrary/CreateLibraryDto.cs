using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.OnlineLibrary
{
    public class CreateLibraryDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateOnlineLibraryDto OnlineLibraryForm { get; set; }
}
}
