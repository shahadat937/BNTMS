using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MembershipTypes
{
    public interface IMembershipTypeDto
    {
        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 