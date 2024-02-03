using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class WithdrawnDoc
    {
        public WithdrawnDoc()
        {
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int WithdrawnDocId { get; set; }
        public string WithdrawnDocName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
