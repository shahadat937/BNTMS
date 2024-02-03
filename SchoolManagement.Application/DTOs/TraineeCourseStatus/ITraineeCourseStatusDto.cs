using System;

namespace SchoolManagement.Application.DTOs.TraineeCourseStatus
{
    public interface ITraineeCourseStatusDto
    {
        public int TraineeCourseStatusId { get; set; }
        public string? TraineeCourseStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 