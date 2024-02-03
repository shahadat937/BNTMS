using System;

namespace SchoolManagement.Application.DTOs.IndividualNotices
{  
    public class CreateIndividualNoticeListDto : IIndividualNoticeDto 
    {
        public int NoticeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
       // public CourseNameIds? CourseNameIds { get; set; }
     //   public string? courseName { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? Status { get; set; }
        public string? NoticeHeading { get; set; }
        public DateTime? EndDate { get; set; }
        public string? NoticeDetails { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public List<IndividualNoticeList>? TraineeListForm { get; set; }
    }
}
 