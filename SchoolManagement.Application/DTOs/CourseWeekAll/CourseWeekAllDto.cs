using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.CourseWeekAll
{
    public class CourseWeekAllDto: ICourseWeekAllDto
    {
     
        public int WeekID { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string WeekName { get; set; }
        public string? Remark { get; set; }

        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
