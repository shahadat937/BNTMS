using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class GuestSpeakerActionStatus
    {
        public int GuestSpeakerActionStatusId { get; set; }
        public string Name { get; set; }
        public double? Mark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
