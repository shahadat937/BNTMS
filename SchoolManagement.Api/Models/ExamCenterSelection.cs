using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ExamCenterSelection
    {
        public int ExamCenterSelectionId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? BnaExamScheduleId { get; set; }
        public int? ExamCenterId { get; set; }
        public int? TraineeId { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaExamSchedule BnaExamSchedule { get; set; }
        public virtual ExamCenter ExamCenter { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
        public virtual TraineeNomination TraineeNomination { get; set; }
    }
}
