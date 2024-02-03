using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AdminAuthority
{
    public class CreateAdminAuthorityDto : IAdminAuthorityDto
    {
        public int AdminAuthorityId { get; set; }
        public string AdminAuthorityName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
