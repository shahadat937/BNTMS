namespace SchoolManagement.Application.DTOs.TdecQuationGroup.CreateTdecQuationGroup
{
    public class CreateTdecQuationGroupDto : ITdecQuationGroupDto
    {
        public int? TdecQuationGroupId { get; set; } 
        public int? BaseSchoolNameId { get; set; } 
        public int? CourseNameId { get; set; } 
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameIds { get; set; }
        public string? BnaSubjectName { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public int? TraineeId { get; set; }
        public int? TdecQuestionNameId { get; set; }
        public string? Pno { get; set; } 
        public bool IsActive { get; set; }
        //public List<TraineeListDto>? TraineeListFormDtos { get; set; }
        public List<TraineeListDto>? TraineeListForm { get; set; }
    }
}
