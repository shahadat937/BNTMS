using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerQuestionName
{
    public class GuestSpeakerQuestionNameDto : IGuestSpeakerQuestionNameDto
    {
        public int GuestSpeakerQuestionNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
