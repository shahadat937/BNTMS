using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerActionStatus
{
    public class CreateGuestSpeakerActionStatusDto : IGuestSpeakerActionStatusDto
    {
        public int GuestSpeakerActionStatusId { get; set; }
        public string? Name { get; set; }
        public double? Mark { get; set; }
        public bool IsActive { get; set; }
    }
}
