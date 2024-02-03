namespace SchoolManagement.Application.DTOs.TraineeAssignmentSubmits
{
    public class CreateTraineeAssignmentSubmitDto : ITraineeAssignmentSubmitDto
    {
        public int TraineeAssignmentSubmitId { get; set; }
        public int? InstructorAssignmentId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? InstructorId { get; set; }
        public int? TraineeId { get; set; }
        public string? AssignmentTopic { get; set; }
        public string? Remarks { get; set; }
        public string? ImageUpload { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public Microsoft.AspNetCore.Http.IFormFile? Doc { get; set; }
    }
}
