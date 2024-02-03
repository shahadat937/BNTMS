using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaPromotionStatus
{
    public interface IBnaPromotionStatusDto
    {
        public int BnaPromotionStatusId { get; set; }
        public string PromotionStatusName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 