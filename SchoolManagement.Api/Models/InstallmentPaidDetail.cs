using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class InstallmentPaidDetail
    {
        public int InstallmentPaidDetailId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeId { get; set; }
        public double? TotalUsd { get; set; }
        public double? TotalBdt { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int? PaymentCompletedStatus { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration CourseDuration { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
