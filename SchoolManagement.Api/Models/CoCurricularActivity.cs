using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CoCurricularActivity
    {
        public int CoCurricularActivityId { get; set; }
        public int TraineeId { get; set; }
        public int CoCurricularActivityTypeId { get; set; }
        public string Participation { get; set; }
        public string Achievement { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CoCurricularActivityType CoCurricularActivityType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
