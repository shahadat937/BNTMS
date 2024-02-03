using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SwimmingDrivingLevel
    {
        public int SwimmingDrivingLevelId { get; set; }
        public int SwimmingDrivingId { get; set; }
        public int LevelTypeId { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CodeValue LevelType { get; set; }
        public virtual SwimmingDriving SwimmingDriving { get; set; }
    }
}
