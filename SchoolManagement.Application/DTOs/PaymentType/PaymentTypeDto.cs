using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentType
{
    public class PaymentTypeDto : IPaymentTypeDto
    {
        public int PaymentTypeId { get; set; }
        public string? PaymentTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
