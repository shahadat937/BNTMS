using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Rank;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Rank
{
    public class CreateRankDto : IRankDto
    {
        public int RankId { get; set; }
        public string RankName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public int CompleteStatus { get; set; }
        public bool IsActive { get; set; }

    }
}
