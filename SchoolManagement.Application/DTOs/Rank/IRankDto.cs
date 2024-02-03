using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Rank
{
    public interface IRankDto
    {

        public int RankId { get; set; }
        public string RankName { get; set; } 
        public string Position { get; set; } 
        public int? MenuPosition { get; set; }
        public int CompleteStatus { get; set; }
        public bool IsActive { get; set; }

    }
}
