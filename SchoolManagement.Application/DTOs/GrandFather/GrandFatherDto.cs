using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GrandFather
{
    public class GrandFatherDto : IGrandFatherDto
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

        public string? GrandFatherType { get; set; }
        public string? Occupation { get; set; }
        public string? DeadStatusValue { get; set; }
        public string? Nationality { get; set; }
    }
}
