using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseBudgetAllocation
{
    public interface ICourseBudgetAllocationDto
    {
        public int CourseBudgetAllocationId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeId { get; set; }
        public int? BudgetCodeId { get; set; }
        public int? PaymentTypeId { get; set; }
        public double? InstallmentAmount { get; set; }
        public DateTime? PaymentDate { get; set; } 
        public DateTime? NextInstallmentDate { get; set; }
        public double? PresentBalance { get; set; }
        public int? PaymentConfirmStatus { get; set; }
        public int? ReceivedStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
