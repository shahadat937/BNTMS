using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaAttendanceRemark
    {
        public BnaAttendanceRemark()
        {
            Attendances = new HashSet<Attendance>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
        }

        public int BnaAttendanceRemarksId { get; set; }
        public string AttendanceRemarksCause { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
    }
}
