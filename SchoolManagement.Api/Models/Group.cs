using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Group
    {
        public Group()
        {
            EducationalQualifications = new HashSet<EducationalQualification>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
    }
}
