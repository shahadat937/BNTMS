using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Groups
{
    public class CreateGroupDto : IGroupDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
