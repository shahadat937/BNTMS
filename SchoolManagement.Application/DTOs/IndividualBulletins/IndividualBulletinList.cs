using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.IndividualBulletins
{
    public class IndividualBulletinList
    {
        public int? CourseInstructorId { get; set; }
        public int? Status { get; set; }
        //public string? TraineePNo { get; set; }
        public int? TraineeId { get; set; }
        //public string? TraineeName { get; set; } 
        //public string? RankPosition { get; set; }
        public bool IsNotify { get; set; }
    }
}
