using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignTrainingCourseReport
{
    public class ForeignTrainingCourseReportDto : IForeignTrainingCourseReportDto
    {
        public int ForeignTrainingCourseReportid { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeId { get; set; }
        public string? Remarks { get; set; }
        public string? Doc { get; set; }
        public bool IsActive { get; set; }

        public string? CourseDuration { get; set; }
        public string? CourseName { get; set; }
        public string? TraineeName { get; set; }
        public string? RankName { get; set; }
        public string? TraineePNo { get; set; }
        public string? RankPosition { get; set; }

    }
}
