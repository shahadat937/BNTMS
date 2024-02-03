using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UserManual
{
    public class CreateUserManualDto : IUserManualDto
    {
        public int UserManualId { get; set; }
        public string? RoleName { get; set; }
        public string? Doc { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public IFormFile? DocFile { get; set; }
    }
}
