﻿using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaExamAttendance
    {
        public int BnaExamAttendanceId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaAttendanceRemarksId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? BnaExamScheduleId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? CourseNameId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? TraineeId { get; set; }
        public int? ExamTypeId { get; set; }
        public string ClassLeaderName { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? AttendanceStatus { get; set; }
        public DateTime? ExamDate { get; set; }
        public bool? IsApproved { get; set; }
        public string ApprovedUser { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BnaAttendanceRemark BnaAttendanceRemarks { get; set; }
        public virtual BnaExamSchedule BnaExamSchedule { get; set; }
        public virtual BnaSemester BnaSemester { get; set; }
        public virtual BnaSemesterDuration BnaSemesterDuration { get; set; }
        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual ClassPeriod ClassPeriod { get; set; }
        public virtual ClassRoutine ClassRoutine { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual ExamType ExamType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
