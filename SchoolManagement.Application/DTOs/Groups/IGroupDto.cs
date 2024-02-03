using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Groups 
{
    public interface IGroupDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
