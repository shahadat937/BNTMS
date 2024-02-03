using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.RoutineNote
{
    public class RoutineNoteDto : IRoutineNoteDto
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

        public virtual string? BaseSchoolName { get; set; }
        public virtual string? BnaSubjectName { get; set; }
        public virtual string? ClassRoutine { get; set; }
        public virtual string? CourseDuration { get; set; }
        public virtual string? CourseName { get; set; }
    }
}
