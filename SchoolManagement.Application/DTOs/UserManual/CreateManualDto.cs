using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.UserManual
{
    public class CreateManualDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateUserManualDto UserManualForm { get; set; }
}
}
