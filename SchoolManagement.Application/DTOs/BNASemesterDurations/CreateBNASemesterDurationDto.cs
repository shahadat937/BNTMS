﻿using System;

namespace SchoolManagement.Application.DTOs.BnaSemesterDurations 
{
    public class CreateBnaSemesterDurationDto : IBnaSemesterDurationDto
    {
        public int BnaSemesterDurationId { get; set; }
        public int? BnaSubjectCurriculamId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? NextSemesterId { get; set; }
        public int? RankId { get; set; }
        public int? SemesterLocationType { get; set; }
        public bool? IsSemesterComplete { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? Location { get; set; }
    }
}
