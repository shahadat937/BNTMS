﻿using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Role
{
    public class RoleDto : IRoleDto
    {


        public string RoleId { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string LoweredRoleName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
