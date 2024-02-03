using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class TraineeMembership
    {
        public int TraineeMembershipId { get; set; }
        public int TraineeId { get; set; }
        public int MembershipTypeId { get; set; }
        public string OrgName { get; set; }
        public string BriefAddress { get; set; }
        public string Appointment { get; set; }
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public string AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual MemberShipType MembershipType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
