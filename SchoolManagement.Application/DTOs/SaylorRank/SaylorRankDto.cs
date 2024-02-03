using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SaylorRank
{
    public class SaylorRankDto : ISaylorRankDto
    {
        public int SaylorRankId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
