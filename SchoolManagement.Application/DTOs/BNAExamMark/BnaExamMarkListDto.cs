using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.BnaExamMark.converter;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaExamMark
{ 
    public class BnaExamMarkListDto 
    {
        public int? BnaExamMarkId { get; set; }
        public int? TraineeId { get; set; }
        public int? BnaExamScheduleId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; } 
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? SchoolDb { get; set; }
        public int? BnaCurriculamTypeId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BranchId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? ClassRoutineId { get; set; }
        public string? TotalMark { get; set; }
        public string? PassMark { get; set; }
        public int? ExamTypeCount { get; set; }
        public double? ObtaintMark { get; set; }
        public int? ResultStatus { get; set; }
        public int? ReExamStatus { get; set; }
        public bool? IsApproved { get; set; }
        public string? IsApprovedBy { get; set; }
        public DateTime? IsApprovedDate { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? SubmissionStatus { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAbsent { get; set; }

        public List<TraineeListFormDto>? traineeListForm { get; set; }

    }
}
