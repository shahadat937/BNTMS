﻿using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class RoutineNote
    {
        public int RoutineNoteId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? CourseWeekId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string RoutineNotes { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual ClassRoutine ClassRoutine { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
    }
}
