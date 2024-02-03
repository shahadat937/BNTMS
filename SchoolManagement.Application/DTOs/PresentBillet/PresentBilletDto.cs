using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.PresentBillet
{
    public class PresentBilletDto : IPresentBilletDto
    {
        public int PresentBilletId { get; set; }
        public string PresentBilletName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
