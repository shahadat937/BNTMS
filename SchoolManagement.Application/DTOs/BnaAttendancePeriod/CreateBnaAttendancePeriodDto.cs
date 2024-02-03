namespace SchoolManagement.Application.DTOs.BnaAttendancePeriod
{
    public class CreateBnaAttendancePeriodDto : IBnaAttendancePeriodDto
    {
        public int BnaAttendancePeriodId { get; set; }
        public string? PeriodName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
