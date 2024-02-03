using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CourseBudgetAllocation
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
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BudgetCode BudgetCode { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
