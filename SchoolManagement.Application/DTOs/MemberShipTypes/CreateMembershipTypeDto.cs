using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MembershipTypes
{
    public class CreateMembershipTypeDto : IMembershipTypeDto
    {
        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
