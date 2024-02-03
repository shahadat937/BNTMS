using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class TraineeStatus
    {
        public TraineeStatus()
        {
            Branches = new HashSet<Branch>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
        }

        public int TraineeStatusId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
    }
}
