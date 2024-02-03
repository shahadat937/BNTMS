using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentDetail
{
    public interface IPaymentDetailDto
    {
        public int PaymentDetailId { get; set; }
        public int? TraineeId { get; set; }
        public string? NumberOfInstallment { get; set; }
        public string? UsdRate { get; set; }
        public string? TotalUsd { get; set; }
        public string? TotalBdt { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
