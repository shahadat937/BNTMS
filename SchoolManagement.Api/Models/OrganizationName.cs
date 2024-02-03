using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class OrganizationName
    {
        public OrganizationName()
        {
            CourseDurations = new HashSet<CourseDuration>();
            InterServiceMarks = new HashSet<InterServiceMark>();
        }

        public int OrganizationNameId { get; set; }
        public string Name { get; set; }
        public int? ForceTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ForceType ForceType { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
    }
}
