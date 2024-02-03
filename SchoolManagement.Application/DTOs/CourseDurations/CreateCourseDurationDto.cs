using System;

namespace SchoolManagement.Application.DTOs.CourseDurations
{
    public class CreateCourseDurationDto : ICourseDurationDto
    {
        public int CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CountryId { get; set; }
        public int? OrganizationNameId { get; set; }
        public int? FiscalYearId { get; set; }
        public string? CourseTitle { get; set; }
        public string? NoOfCandidates { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? DurationTo { get; set; }
        public string? Professional { get; set; }
        public string? Nbcd { get; set; }
        public string? Remark { get; set; }
        public int? IsCompletedStatus { get; set; }
        public int? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? NbcdSchoolId { get; set; }
        public DateTime? NbcdDurationFrom { get; set; }
        public DateTime? NbcdDurationTo { get; set; }
        public int? NbcdStatus { get; set; }
        public int? ComeFromNbcdDurationId { get; set; }
    }
}
