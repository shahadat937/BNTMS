using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AssignmentMarkEntry
{
    public class CreateAssignmentMarkEntryDto : IAssignmentMarkEntryDto  
    {
        public int AssignmentMarkEntryId { get; set; }
        public int? TraineeAssignmentSubmitId { get; set; }
        public int? InstructorAssignmentId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? TraineeId { get; set; }
        public double? AssignmentMark { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
