using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaExamMark.converter
{ 
    public class ApproveTraineeListFormDto
    {
        public int BnaExamMarkId { get; set; }
        public string? TraineePNo { get; set; }
        public int? TraineeId { get; set; }
        public int? TraineeNominationId { get; set; }
        public string? TraineeName { get; set; }
        public string? RankPosition { get; set; }
        public double? ObtaintMark { get; set; }
        public int? ResultStatus { get; set; }
        public int? ReExamStatus { get; set; }
        public int? ExamMarkRemarksId { get; set; }
        public int? SubmissionStatus { get; set; }
        public int? CourseSectionId { get; set; }

        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}
