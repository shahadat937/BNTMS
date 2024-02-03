using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PresentBillet
{
    public interface IPresentBilletDto
    {

        public int PresentBilletId { get; set; }
        public string PresentBilletName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
