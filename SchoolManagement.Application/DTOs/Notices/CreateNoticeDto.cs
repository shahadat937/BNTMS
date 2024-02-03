using System;

namespace SchoolManagement.Application.DTOs.Notice
{
    public class CreateNoticeDto : INoticeDto
    {
        public int NoticeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; } 
        public int? CourseNameIds { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseInstructorId { get; set; }
        public string? NoticeHeading { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public string? NoticeDetails { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
    }
}
