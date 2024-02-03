using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Branch
{
    public class CreateBranchDto : IBranchDto
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
