using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RecordOfService
{
    public interface IRecordOfServiceDto
    {
        public int RecordOfServiceId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? ShipEstablishment { get; set; }
        public string? Appointment { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 