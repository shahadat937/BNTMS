using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.IndividualNotices
{
    public class IndividualNoticeList
    {
        public int? CourseNameId { get; set; }
        public int? Status { get; set; }
        public string? TraineePNo { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; } 
        public string? RankPosition { get; set; }
        public bool IsNotify { get; set; }
    }
}
