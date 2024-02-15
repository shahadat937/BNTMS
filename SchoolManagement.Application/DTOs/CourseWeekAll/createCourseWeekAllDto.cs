using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.CourseWeekAll
{
    public class createCourseWeekAllDto:ICourseWeekAllDto
    {
     
        public int? WeekID { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? WeekName { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
