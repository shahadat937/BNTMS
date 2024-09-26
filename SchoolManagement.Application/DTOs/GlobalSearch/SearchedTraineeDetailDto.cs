using SchoolManagement.Application.DTOs.CourseDurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.GlobalSearch
{
    public class SearchedTraineeDetailDto
    {
        public List<CourseDurationDto> CourseDurations { get; set; } = new List<CourseDurationDto>();
        public int TotalCourse {  get; set; }
        public int CompletedCourse { get; set; }
        public int UpcomingCourse {  get; set; }
    }
}
