using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.CourseDurations
{
    public class UpdateNbcdCourseDurationDto
    {
        public int CourseDurationId { get; set; }
       // public int? NbcdSchoolId { get; set; }
        public DateTime? NbcdDurationFrom { get; set; }
        public DateTime? NbcdDurationTo { get; set; }
        public int? NbcdStatus { get; set; }
    }
}
