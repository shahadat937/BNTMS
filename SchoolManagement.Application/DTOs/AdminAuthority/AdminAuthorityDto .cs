using System;

namespace SchoolManagement.Application.DTOs.AdminAuthority
{
    public class AdminAuthorityDto : IAdminAuthorityDto
    {
        public int AdminAuthorityId { get; set; }
        public string AdminAuthorityName { get; set; } = null!;
        public int? MenuPosition { get; set; } 
        public bool IsActive { get; set; }
    }
}
