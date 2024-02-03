using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignTrainingCourseReport
{
    public class CreateForeignTrainingCourseReportDto : IForeignTrainingCourseReportDto
    {
        public int ForeignTrainingCourseReportid { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeId { get; set; }
        public string? Remarks { get; set; }
        public string? Doc { get; set; }
        public bool IsActive { get; set; }

        public IFormFile? DocFile { get; set; }
    }
}
