using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaExamMark.converter
{ 
    public class TraineeListFormDto
    {
        public int? CourseNameId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? Status { get; set; }
        public string? TraineePNo { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; }
        public string? RankPosition { get; set; }
        public double? ObtaintMark { get; set; }
        public int? ResultStatus { get; set; }
        public int? ReExamStatus { get; set; }
        public int? ExamMarkRemarksId { get; set; }
        public int? CourseSectionId { get; set; }
        public bool? AttendanceStatus { get; set; } 
        public int? AttendanceId { get; set; } 

    }
}
