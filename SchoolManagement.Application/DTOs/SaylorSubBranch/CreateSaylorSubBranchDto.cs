using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SaylorSubBranch
{
    public class CreateSaylorSubBranchDto : ISaylorSubBranchDto  
    {
        public int SaylorSubBranchId { get; set; }
        public int? SaylorBranchId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
