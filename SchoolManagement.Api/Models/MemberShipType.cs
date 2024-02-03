using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MemberShipType
    {
        public MemberShipType()
        {
            TraineeMemberships = new HashSet<TraineeMembership>();
        }

        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeMembership> TraineeMemberships { get; set; }
    }
}
