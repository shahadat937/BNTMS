using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuationGroup
{
    public class CreateTdecQuationGroupDto : ITdecQuationGroupDto
    {
        public int TdecQuationGroupId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        public int? TraineeId { get; set; }
        public int? TdecQuestionNameId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
