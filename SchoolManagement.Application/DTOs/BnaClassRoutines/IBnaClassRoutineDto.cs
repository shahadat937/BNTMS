﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.BnaClassRoutines
{
    public interface IBnaClassRoutineDto
    {
        public int ClassRoutineId { get; set; }
        public string? BnaSubjectCurriculumId { get; set; }
        public string? DepartmentId { get; set; }
        public int? CourseModuleId { get; set; }
        public string? BnaSemesterId { get; set; }
        public string? ClassPeriodId { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? PeriodFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? PeriodTo { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? ClassCountPeriod { get; set; }
        public int? SubjectCountPeriod { get; set; }
        public string? CourseNameId { get; set; }
        public string? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string? ClassLocation { get; set; }
        public int? BranchId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? TraineeId { get; set; }
        public string? CourseSectionId { get; set; }
        public int? CourseWeekId { get; set; }
        public string? Remarks { get; set; }
        public string? TimeDuration { get; set; }
        public DateTime? Date { get; set; }
        public int? ClassTypeId { get; set; }
        public string? ClassRoomName { get; set; }
        public string? ClassTopic { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
