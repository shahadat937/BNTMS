namespace SchoolManagement.Application.DTOs.BnaAttendanceRemarks
{  
    public class CreateBnaAttendanceRemarkDto : IBnaAttendanceRemarkDto
    {
        public int BnaAttendanceRemarksId { get; set; }
        public string? AttendanceRemarksCause { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
