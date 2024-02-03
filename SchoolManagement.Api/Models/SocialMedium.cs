using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SocialMedium
    {
        public int SocialMediaId { get; set; }
        public int TraineeId { get; set; }
        public int SocialMediaTypeId { get; set; }
        public string SocialMediaAccountName { get; set; }
        public string AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual SocialMediaType SocialMediaType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
