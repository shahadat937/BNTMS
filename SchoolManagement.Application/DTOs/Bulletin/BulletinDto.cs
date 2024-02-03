using System;

namespace SchoolManagement.Application.DTOs.Bulletin
{
    public class BulletinDto : IBulletinDto 
    {
        public int BulletinId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public string? BuletinDetails { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? BaseSchoolName { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDuration { get; set; }
    }
}
