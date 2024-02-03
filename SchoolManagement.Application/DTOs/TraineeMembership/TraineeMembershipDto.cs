using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeMembership
{
    public class TraineeMembershipDto : ITraineeMembershipDto
    {

        public int TraineeMembershipId { get; set; }
        public int TraineeId { get; set; }
        public int MembershipTypeId { get; set; }
        public string OrgName { get; set; } = null!;
        public string BriefAddress { get; set; } = null!;
        public string Appointment { get; set; } = null!;
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? MembershipType { get; set; }

    }
}
