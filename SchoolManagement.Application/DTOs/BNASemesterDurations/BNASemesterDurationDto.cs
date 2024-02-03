using System;
namespace SchoolManagement.Application.DTOs.BnaSemesterDurations
{
    public class BnaSemesterDurationDto : IBnaSemesterDurationDto
    {
        public int BnaSemesterDurationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? NextSemesterId { get; set; }
        public int? RankId { get; set; }
        public int? SemesterLocationType { get; set; }
        public bool? IsSemesterComplete { get; set; }
        public DateTime?  StartDate { get; set; }
        public DateTime?  EndDate { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? Location { get; set; }

        public string? BnaSemesterName { get; set; }
        public string? CourseDuration { get; set; }
        public string? BatchName { get; set; }  
        public string? Rank { get; set; }
        public string? LocationType { get; set; } 
    }
}

