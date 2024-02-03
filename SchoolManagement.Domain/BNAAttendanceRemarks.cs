using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaAttendanceRemarks : BaseDomainEntity
    {
        public BnaAttendanceRemarks()
        {
            Attendances = new HashSet<Attendance>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
        }

        public int BnaAttendanceRemarksId { get; set; }
        public string? AttendanceRemarksCause { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
