using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecActionStatus
{
    public class TdecActionStatusDto : ITdecActionStatusDto
    {
        public int TdecActionStatusId { get; set; }
        public string? Name { get; set; }
        public double? Mark { get; set; }
        public bool IsActive { get; set; }
    }
}
