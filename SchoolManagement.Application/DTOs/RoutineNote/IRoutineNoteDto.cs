using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RoutineNote
{
    public interface IRoutineNoteDto
    {
        public int RoutineNoteId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseWeekId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string? RoutineNotes { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
