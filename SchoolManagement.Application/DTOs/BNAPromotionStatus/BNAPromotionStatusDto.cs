using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaPromotionStatus
{
    public class BnaPromotionStatusDto : IBnaPromotionStatusDto
    {
        public int BnaPromotionStatusId { get; set; }
        public string PromotionStatusName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
