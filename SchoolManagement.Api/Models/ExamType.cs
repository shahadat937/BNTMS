using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ExamType
    {
        public ExamType()
        {
            Attendances = new HashSet<Attendance>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamSchedules = new HashSet<BnaExamSchedule>();
            EducationalQualifications = new HashSet<EducationalQualification>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int ExamTypeId { get; set; }
        public string ExamTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamSchedule> BnaExamSchedules { get; set; }
        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
