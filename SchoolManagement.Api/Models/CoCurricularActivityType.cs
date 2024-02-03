using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CoCurricularActivityType
    {
        public CoCurricularActivityType()
        {
            CoCurricularActivities = new HashSet<CoCurricularActivity>();
        }

        public int CoCurricularActivityTypeId { get; set; }
        public string CoCurricularActivityName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CoCurricularActivity> CoCurricularActivities { get; set; }
    }
}
