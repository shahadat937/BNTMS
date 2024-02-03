using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuationGroup
{
    public class TdecQuationGroupDto : ITdecQuationGroupDto
    {
        public int TdecQuationGroupId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public int? TraineeId { get; set; }
        public int? TdecQuestionNameId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? SchoolName { get; set; }
        public string? CourseName { get; set; }
        public string? SubjectName { get; set; }
        public string? TraineeName { get; set; }
        public string? TraineePno { get; set; }
        public string? TraineeRank { get; set; }
        public string? TdecQuestionName { get; set; }
        public string? CourseDuration { get; set; }
    }
}
