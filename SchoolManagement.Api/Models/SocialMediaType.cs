using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SocialMediaType
    {
        public SocialMediaType()
        {
            SocialMedia = new HashSet<SocialMedium>();
        }

        public int SocialMediaTypeId { get; set; }
        public string SocialMediaTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SocialMedium> SocialMedia { get; set; }
    }
}
