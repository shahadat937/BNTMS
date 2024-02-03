﻿using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.ClassRoutine
{
    public class CreateClassRoutineDto : IClassRoutineDto
    {
        public int ClassRoutineId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? ClassCountPeriod { get; set; }
        public int? SubjectCountPeriod { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BranchId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? CourseWeekId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? AttendanceComplete { get; set; }
        public int? ResultSubmissionStatus { get; set; }
        public int? FinalApproveStatus { get; set; }
        public int? ExamMarkComplete { get; set; }
        public string? ClassLocation { get; set; }
        public string? Remarks { get; set; }
        public string? TimeDuration { get; set; }
        public string? ClassRoomName { get; set; }
        public string? ClassTopic { get; set; }


        public DateTime? Date { get; set; }
        public int? ClassTypeId { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
