using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GrandFather
{
    public interface IGrandFatherDto
    {

        public int GrandFatherId { get; set; }
        public int TraineeId { get; set; }
        public int GrandFatherTypeId { get; set; }
        public int OccupationId { get; set; }
        public int NationalityId { get; set; }
        public string? GrandFathersName { get; set; }
        public int? Age { get; set; }
        public int DeadStatus { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
