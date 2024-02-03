using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic; 

namespace SchoolManagement.Domain
{
    public class GuestSpeakerActionStatus:BaseDomainEntity
    {
        public GuestSpeakerActionStatus()
        {
            GuestSpeakerGroupResults = new HashSet<GuestSpeakerGroupResult>();
        }

        public int GuestSpeakerActionStatusId { get; set; }
        public string? Name { get; set; }
        public double? Mark { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GuestSpeakerGroupResult> GuestSpeakerGroupResults { get; set; }
    }
}
