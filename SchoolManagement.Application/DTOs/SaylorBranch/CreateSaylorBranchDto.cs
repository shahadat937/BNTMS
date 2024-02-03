using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SaylorBranch
{
    public class CreateSaylorBranchDto : ISaylorBranchDto  
    {
        public int SaylorBranchId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
