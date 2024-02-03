using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NewEntryEvaluation
{
    public class NewEntryEvaluationDto : INewEntryEvaluationDto
    {
        public int NewEntryEvaluationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseWeekId { get; set; }
        public string? CourseWeek { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; }
        public string? TraineePNo { get; set; }
        public string? RankPosition { get; set; }
        public int? TraineeNominationId { get; set; }
        public double? Noitikota { get; set; }
        public double? Sahonsheelota { get; set; }
        public double? Utsaho { get; set; }
        public double? Samayanubartita { get; set; }
        public double? Manovhab { get; set; }
        public double? Udyam { get; set; }
        public double? KhapKhawano { get; set; }
        public double? Onyano { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
