using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.GlobalSearch
{
    public class CourseSummaryDto
    {
        public int TotalTrainee { get; set; }
        public int TotalInstructor { get; set; }
        public int TotalSubject {  get; set; }
        public int TotalCourseTraineeAllTime { get; set; }
    }
}
