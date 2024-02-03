using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InstallmentPaidDetail
{
    public class InstallmentPaidDetailDto : IInstallmentPaidDetailDto 
    {
        public int InstallmentPaidDetailId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeId { get; set; }
        public double? TotalUsd { get; set; }
        public double? TotalBdt { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int? PaymentCompletedStatus { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}

