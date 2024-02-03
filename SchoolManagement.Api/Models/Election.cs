using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Election
    {
        public int ElectionId { get; set; }
        public int TraineeId { get; set; }
        public int ElectedId { get; set; }
        public string InstituteName { get; set; }
        public string AppointmentName { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? DurationTo { get; set; }
        public string AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Elected Elected { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
