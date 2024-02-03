using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.WeekName
{
    public interface IWeekNameDto
    {
        public int WeekNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
