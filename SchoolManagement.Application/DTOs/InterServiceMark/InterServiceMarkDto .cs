namespace SchoolManagement.Application.DTOs.InterServiceMark
{
    public class InterServiceMarkDto: IInterServiceMarkDto
    {
        public int InterServiceMarkId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CountryId { get; set; }
        public int? OrganizationNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; }
        public string? TraineePNo { get; set; }
        public string? RankPosition { get; set; }
        public string? CoursePosition { get; set; }
        public string? ObtaintMark { get; set; }
        public string? Doc { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public string? CourseName { get; set; }
        public string? Document { get; set; }
        public string? CourseDuration { get; set; }
        public string? OrganizationName { get; set; }
    }
}
