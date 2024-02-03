using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Occupation
    {
        public Occupation()
        {
            GrandFathers = new HashSet<GrandFather>();
            ParentRelativeOccupations = new HashSet<ParentRelative>();
            ParentRelativePreviousOccupations = new HashSet<ParentRelative>();
        }

        public int OccupationId { get; set; }
        public string OccupationName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GrandFather> GrandFathers { get; set; }
        public virtual ICollection<ParentRelative> ParentRelativeOccupations { get; set; }
        public virtual ICollection<ParentRelative> ParentRelativePreviousOccupations { get; set; }
    }
}
