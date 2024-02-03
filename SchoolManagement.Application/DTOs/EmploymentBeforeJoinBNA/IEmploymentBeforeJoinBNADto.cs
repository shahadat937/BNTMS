using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna
{
    public interface IEmploymentBeforeJoinBnaDto
    {
        public int EmploymentBeforeJoinBnaId { get; set; }
        public int TraineeId { get; set; }
        public string Name { get; set; } 
        public string Appointment { get; set; } 
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public string? Remarks { get; set; }
        public string? AdditionalInformation { get; set; } 
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
