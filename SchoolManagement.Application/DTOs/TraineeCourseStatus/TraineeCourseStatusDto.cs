using System;

namespace SchoolManagement.Application.DTOs.TraineeCourseStatus
{
    public class TraineeCourseStatusDto : ITraineeCourseStatusDto
    {
        public int TraineeCourseStatusId { get; set; }
        public string? TraineeCourseStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}

