using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Branch
{
    public interface IBranchDto
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
