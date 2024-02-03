using SchoolManagement.Domain;
using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;
 
namespace SchoolManagement.Domain
{
    public class MilitaryTraining : BaseDomainEntity
    {
        public int MilitaryTrainingId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? DateAttended { get; set; }
        public string? LocationOfTrg { get; set; }
        public string? DetailsOfCourse { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
