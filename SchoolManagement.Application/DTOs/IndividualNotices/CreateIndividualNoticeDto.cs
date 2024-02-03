using System;

namespace SchoolManagement.Application.DTOs.IndividualNotices
{ 
    public class CreateIndividualNoticeDto : IIndividualNoticeDto 
    {
        public int IndividualNoticeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; } 
        public int? CourseNameIds { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? Status { get; set; }
        public string? NoticeHeading { get; set; }
        public DateTime? EndDate { get; set; }
        public string? NoticeDetails { get; set; } 
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
    }
}
