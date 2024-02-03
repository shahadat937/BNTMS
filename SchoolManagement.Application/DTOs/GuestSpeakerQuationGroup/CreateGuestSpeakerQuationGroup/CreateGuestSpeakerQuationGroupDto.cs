namespace SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.CreateGuestSpeakerQuationGroup
{
    public class CreateGuestSpeakerQuationGroupDto : IGuestSpeakerQuationGroupDto
    {
        public int? GuestSpeakerQuationGroupId { get; set; } 
        public int? BaseSchoolNameId { get; set; } 
        public int? CourseNameId { get; set; } 
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameIds { get; set; }
        public string? BnaSubjectName { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        public int? TraineeId { get; set; }
        public int? GuestSpeakerQuestionNameId { get; set; }
        public string? Pno { get; set; } 
        public bool IsActive { get; set; }
        public List<TraineeListDtos>? TraineeListForm { get; set; }
    }
}
